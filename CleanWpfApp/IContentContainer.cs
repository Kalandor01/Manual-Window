﻿namespace CleanWpfApp
{
    // Interface that's required to be implemented by all classes that
    // can get get called back when a BindProduct become available.
    internal interface IContentContainer
    {
        /// Function that gets called back when the BindProduct becomes
        /// available.
        /// "contentType" - Mime type of bindproduct
        /// "content" - BindProduct that's just been created.
        void OnContentReady(ContentType contentType, object content, Uri uri, object navState);

        // Function that gets called each time number of bytes equal to
        // bytesInterval is read
        void OnNavigationProgress(Uri uri, long bytesRead, long maxBytes);

        // Function that gets called when Close() is called on the stream.
        void OnStreamClosed(Uri uri);
    }

    // This is the NavigationStatus for the IContentContainers
    internal enum NavigationStatus
    {
        // Currently idle
        Idle,
        // Currently navigating the navigable item
        Navigating,
        // An error occurred during Navigation
        NavigationFailed,
        // Root Element hooked up to source window or frame        
        Navigated,
        // Navigation was stopped
        Stopped
    }
}