﻿using CozyPixel.Command;
using CozyPixel.Draw;
using CozyPixel.Helper;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CozyPixel.Tool
{
    public class PixelFill : PixelToolBase
    {
        public override bool WillModify { get { return true; } }

        public PixelFill(Color holder)
            :base(holder)
        {

        }

        protected override bool OnEnd(Point p)
        {
            base.OnEnd(p);

            if (Target != null && ColorHolder != null && Target.IsReady)
            {
                var mapp    = p.ToMap(Target.GridWidth);
                var points  = GenericDraw.GetPointsWithSameColor(Target, mapp, Target.ReadPixel(mapp));

                var command = new DrawPixelCommand()
                {
                    Points  = points.Select(x => new KeyValuePair<Point, Color>(x.Key, ColorHolder)),
                    Target  = Target,
                };
                CommandManager.Instance.Do(command);

                Target.UpdateDrawable();
                return true;
            }
            return false;
        }
    }
}
