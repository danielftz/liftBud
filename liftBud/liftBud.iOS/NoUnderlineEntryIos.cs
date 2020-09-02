using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using liftBud.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(NoUnderlineEntryIos))]
namespace liftBud.iOS
{
    public class NoUnderlineEntryIos:EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            this.Control.BorderStyle = UIKit.UITextBorderStyle.None;
        }
    }
}