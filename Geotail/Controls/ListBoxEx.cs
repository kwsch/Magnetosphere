using System.Drawing;
using System.Windows.Forms;

namespace Geotail
{
    public sealed partial class ListBoxEx : ListBox
    {
        private readonly Size ImageSize;
        private readonly StringFormat StringFormat;
        private readonly Font TitleFont;
        private readonly Font DetailsFont;

        public ListBoxEx(Font titleFont, Font detailsFont, Size imageSize,
                         StringAlignment aligment, StringAlignment lineAligment)
        {
            TitleFont = titleFont;
            DetailsFont = detailsFont;
            ImageSize = imageSize;
            ItemHeight = ImageSize.Height + Margin.Vertical;
            StringFormat = new StringFormat
            {
                Alignment = aligment,
                LineAlignment = lineAligment
            };
            TitleFont = titleFont;
            DetailsFont = detailsFont;
        }

        public ListBoxEx()
        {
            InitializeComponent();
            ImageSize = new Size(64,64);
            ItemHeight = ImageSize.Height + Margin.Vertical;
            StringFormat = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near
            };
            TitleFont = new Font(Font, FontStyle.Bold);
            DetailsFont = new Font(Font, FontStyle.Regular);
        }


        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (Items.Count <= 0)
                return;
            var item = (ListBoxExItem)Items[e.Index];
            item.DrawItem(e, Margin, TitleFont, DetailsFont, StringFormat, ImageSize);
        }
    }
}
