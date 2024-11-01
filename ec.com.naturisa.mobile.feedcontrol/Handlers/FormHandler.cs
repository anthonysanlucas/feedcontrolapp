#if IOS
using UIKit;
using Foundation;
#endif

#if ANDROID
using Android.Content.Res;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif

namespace ec.com.naturisa.mobile.feedcontrol.Handlers
{
    public static class FormHandler
    {
        public static void RemoveBorders()
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(
                "Borderless",
                (handler, view) =>
                {
#if ANDROID
                    handler.PlatformView.Background = null;
                    handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
                    handler.PlatformView.BackgroundTintList =
                        Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
#elif IOS
                    handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                    handler.PlatformView.Layer.BorderWidth = 0;
                    handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
                }
            );

            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping(
                "Borderless",
                (handler, view) =>
                {
#if ANDROID
                    handler.PlatformView.Background = null;
                    handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
                    handler.PlatformView.BackgroundTintList =
                        Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
#elif IOS
                    handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                    handler.PlatformView.Layer.BorderWidth = 0;
                    handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
                }
            );

            Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping(
                "Borderless",
                (handler, view) =>
                {
#if ANDROID
                    handler.PlatformView.Background = null;
                    handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
                    handler.PlatformView.BackgroundTintList =
                        Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
#elif IOS
                    handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                    handler.PlatformView.Layer.BorderWidth = 0;
                    handler.PlatformView.Layer.CornerRadius = 0;
#endif
                }
            );

            Microsoft.Maui.Handlers.SearchBarHandler.Mapper.AppendToMapping(
                "Borderless",
                (handler, view) =>
                {
#if ANDROID
        if (handler.PlatformView is AndroidX.AppCompat.Widget.SearchView searchView)
        {           
            int plateId = searchView.Context.Resources.GetIdentifier("android:id/search_plate", null, null);
            if (plateId != 0)
            {
                var plate = searchView.FindViewById(plateId);
                if (plate is Android.Views.View plateView)
                {
                    plateView.SetBackgroundColor(Android.Graphics.Color.Transparent);
                }
            }
            
            searchView.SetIconifiedByDefault(false);
            searchView.Iconified = false;
            searchView.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
#elif IOS
        if (handler.PlatformView is UIKit.UISearchBar searchBar)
        {
            searchBar.BackgroundImage = new UIKit.UIImage();
        }
#endif
                }
            );

            Microsoft.Maui.Handlers.DatePickerHandler.Mapper.AppendToMapping(
               "Borderless",
               (handler, view) =>
               {
#if ANDROID
                    handler.PlatformView.Background = null;
                    handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
                    handler.PlatformView.BackgroundTintList =
                        ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
#elif IOS
                    handler.PlatformView.BackgroundColor = UIColor.Clear;
                    handler.PlatformView.Layer.BorderWidth = 0;
                    handler.PlatformView.BorderStyle = UITextBorderStyle.None;
#endif
               }
           );
        }
    }
}
