using System.Drawing;

namespace FieldEffect.Models
{
    public class BatteryIcon
    {
        public enum BatteryOrientation
        {
            /// <summary>
            /// Battery is oriented horizontally, leftmost value is zero.
            /// </summary>
            HorizontalL,

            /// <summary>
            /// Battery is oriented vertically, bottom value is zero.
            /// </summary>
            VerticalB,

            /// <summary>
            /// Battery is oriented horizontally, with rightmost value as zero.
            /// </summary>
            HorizontalR,

            /// <summary>
            /// Battery is oriented vertically, with topmost value as zero.
            /// </summary>
            VerticalT
        }

        private Icon _batteryTemplate;
        private Icon _renderedBattery;
        private Rectangle _batteryLevelMask;
        private BatteryOrientation _batteryOrientation;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="batteryTemplate">An icon containing the main artwork for the battery</param>
        /// <param name="batteryLevelMask">A rectangle on the template that we will draw the battery level in</param>
        /// <param name="batteryOrientation">The orientation of the battery icon</param>
        public BatteryIcon(Icon batteryTemplate, Rectangle batteryLevelMask, BatteryOrientation batteryOrientation)
        {
            _batteryTemplate = batteryTemplate;
            _batteryLevelMask = batteryLevelMask;
            _renderedBattery = batteryTemplate;
            _batteryOrientation = batteryOrientation;
        }

        /// <summary>
        /// Battery level, from 0 - 100
        /// </summary>
        public int BatteryLevel { get; set; }

        public Icon RenderedIcon
        {
            get
            {
                return _renderedBattery;
            }
        }

        public void Render(Graphics g)
        {
            Rectangle batteryRect = new Rectangle();
            if (_batteryOrientation == BatteryOrientation.HorizontalL)
            {
                batteryRect = new Rectangle(
                    _batteryLevelMask.X,
                    _batteryLevelMask.Y,
                    (int)(_batteryLevelMask.Width * (BatteryLevel / 100.0)),
                    _batteryLevelMask.Height
                );
            }

            g.Clear(Color.Transparent);
            g.DrawIcon(_batteryTemplate, 0, 0);
            using (var brush = new SolidBrush(BatteryLevel <= 10 ? Color.Red : Color.LightGray))
            {
                g.FillRectangle(brush, batteryRect);
            }
        }
    }
}
