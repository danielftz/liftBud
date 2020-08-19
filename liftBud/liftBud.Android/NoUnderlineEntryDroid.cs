using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using liftBud.Droid;
using liftBud.Model;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NoUnderlineEntry),typeof(NoUnderlineEntryDroid))]
namespace liftBud.Droid
{
    public class NoUnderlineEntryDroid : EntryRenderer
    {
        public NoUnderlineEntryDroid(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            this.Control.Background = null;
        }
    }
}