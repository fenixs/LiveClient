using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LiveClient.Views
{
    class PicPlayer : FrameworkElement
    {

        private WriteableBitmap _bitmap = null;



        private System.Drawing.Size _BitmapSize;

        public System.Drawing.Size BitmapSize
        {
            get { return _BitmapSize; }
            set {
                    if (value != _BitmapSize)
                    {
                        _BitmapSize = value;
                        InitBitmap();
                    }
                }
        }
        
        
        

        public PicPlayer()
        {
            _BitmapSize = new System.Drawing.Size(400, 300);
            
            InitBitmap();
        }

        private void InitBitmap()
        {
            _bitmap = new WriteableBitmap(_BitmapSize.Width, _BitmapSize.Height, 96, 96, PixelFormats.Rgb24, null);

        }
        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {
            //base.OnRender(drawingContext);
            drawingContext.PushTransform(new ScaleTransform(1, -1, 0, RenderSize.Height / 2));
            drawingContext.DrawImage(_bitmap, new Rect(0, 0, RenderSize.Width, RenderSize.Height));
        }
    }
}
