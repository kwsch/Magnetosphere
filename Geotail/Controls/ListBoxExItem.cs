using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Geotail.Properties;
using Magnetosphere;

namespace Geotail
{
    public class ListBoxExItem
    {
        public readonly Bot Bot;
        public int ID { get; set; }
        public string Title => Bot.Name;
        public string Line1 => $"{Bot.Messenger.Summary}{Environment.NewLine}{Bot.State}";
        public string Line2 => $"{Bot.Routine.Status}";
        public string ImageName => Bot.CurrentGame?.GameID.ToString();

        public ListBoxExItem(Bot bot, int id)
        {
            Bot = bot;
            ID = id;
        }

        public void DrawItem(DrawItemEventArgs e, Padding margin, Font titleFont, Font detailsFont, StringFormat aligment, Size imageSize)
        {
            // if selected, mark the background differently
            var g = e.Graphics;
            var b = e.Bounds;
            var color = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                ? SystemBrushes.Control
                : SystemBrushes.ControlLightLight;
            g.FillRectangle(color, b);

            // draw some item separator
            g.DrawLine(SystemPens.ControlText, b.X, b.Y, b.X + b.Width, b.Y);

            // draw item image
            try
            {
                var img = File.Exists(ImageName) ? Image.FromFile(ImageName) : (Image)Resources.ResourceManager.GetObject(Bot.Config.DeviceType.ToString());
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                if (img.Width <= 64 || img.Height <= 64)
                    g.DrawImage(img, b.X + margin.Left, b.Y + margin.Top, imageSize.Width, imageSize.Height);
            }
            catch (Exception ex)
            {
                Bot.LogError(ex.Message);
            }

            // calculate bounds for title text drawing
            var x = b.X + margin.Horizontal + imageSize.Width;
            var w = b.Width - margin.Right - imageSize.Width - margin.Horizontal;
            var y = b.Y + margin.Top;
            var h = (int) titleFont.GetHeight() + 2;
            var titleBounds = new Rectangle(x, y, w, h);
            g.DrawString(Title, titleFont, SystemBrushes.ControlText, titleBounds, aligment);

            // calculate bounds for details text drawing
            y += (int)titleFont.GetHeight() + 2 + margin.Vertical;
            h = b.Height - margin.Bottom - (int) titleFont.GetHeight() - 2 - margin.Vertical - margin.Top;
            var line1Bounds = new Rectangle(x, y, w, h);
            g.DrawString(Line1, detailsFont, SystemBrushes.ButtonShadow, line1Bounds, aligment);

            if (Bot.State != DeviceState.Disconnected)
            {
                y += (int)titleFont.GetHeight() + 12 + margin.Vertical;
                h = (int)titleFont.GetHeight() + 2;
                var line2Bounds = new Rectangle(x, y, w, h);
                g.DrawString(Line2, detailsFont, SystemBrushes.ButtonShadow, line2Bounds, aligment);
            }

            // put some focus rectangle
            e.DrawFocusRectangle();
        }
    }
}