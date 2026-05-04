using Microsoft.Maui.Controls;

namespace ScrollAndZoom;

public class ScrollAndZoomView : ScrollView
{
    public double MaxZoom {get; set; } = 2;

    public ScrollAndZoomView()
    {
#if IOS

        GestureRecognizers.Add(new TapGestureRecognizer()
        {
            NumberOfTapsRequired = 2,
            Command = new Command(() => { this.ResetZoom(); })
        });
#endif

        this.HandlerChanged += OnHandlerChanged;
    }

    private void OnHandlerChanged(Object? sender, EventArgs e)
    {
        if (sender is not ScrollView scrollView)
        {
            return;
        }

#if IOS
        if (scrollView?.Handler?.PlatformView is not UIKit.UIScrollView uiScrollView)
        {
            return;
        }

        uiScrollView.MinimumZoomScale = 1f;
        uiScrollView.MaximumZoomScale = (float)MaxZoom;

        uiScrollView.ViewForZoomingInScrollView += (UIKit.UIScrollView sv) => { return sv.Subviews[0]; };
#endif
    }

    public void ResetZoom()
    {
#if IOS
        if (this?.Handler?.PlatformView is UIKit.UIScrollView uiScrollView)
        {
            uiScrollView.SetZoomScale(1, false);
        }
#endif
    }
}