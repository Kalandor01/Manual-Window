﻿namespace CleanWpfApp
{
    // Implements ETW tracing for Avalon Managed Code
    static internal class EventTrace
    {
        internal enum Level : byte
        {
            LogAlways = 0,
            Critical = 1,
            Error = 2,
            Warning = 3,
            Info = 4,
            Verbose = 5,
            PERF = 16,
            PERF_LOW = 17,
            PERF_MED = 18,
            PERF_HIGH = 19,
        }

        [Flags]
        internal enum Keyword
        {
            KeywordGeneral = 0x1,
            KeywordPerf = 0x2,
            KeywordText = 0x4,
            KeywordInput = 0x8,
            KeywordAnnotation = 0x10,
            KeywordXamlBaml = 0x20,
            KeywordXPS = 0x40,
            KeywordAnimation = 0x80,
            KeywordLayout = 0x100,
            KeywordHosting = 0x400,
            KeywordHeapMeter = 0x800,
            KeywordGraphics = 0x1000,
            KeywordDispatcher = 0x2000,
        }

        internal enum Event : ushort
        {
            WClientCreateVisual = 1,
            WClientAppCtor = 2,
            WClientAppRun = 3,
            WClientString = 4,
            WClientStringBegin = 5,
            WClientStringEnd = 6,
            WClientPropParentCheck = 7,
            UpdateVisualStateStart = 8,
            UpdateVisualStateEnd = 9,
            PerfElementIDName = 10,
            PerfElementIDAssignment = 11,
            WClientFontCache = 1001,
            WClientInputMessage = 2001,
            StylusEventQueued = 2002,
            TouchDownReported = 2003,
            TouchMoveReported = 2004,
            TouchUpReported = 2005,
            ManipulationReportFrame = 2006,
            ManipulationEventRaised = 2007,
            PenThreadPoolThreadAcquisition = 2008,
            CreateStickyNoteBegin = 3001,
            CreateStickyNoteEnd = 3002,
            DeleteTextNoteBegin = 3003,
            DeleteTextNoteEnd = 3004,
            DeleteInkNoteBegin = 3005,
            DeleteInkNoteEnd = 3006,
            CreateHighlightBegin = 3007,
            CreateHighlightEnd = 3008,
            ClearHighlightBegin = 3009,
            ClearHighlightEnd = 3010,
            LoadAnnotationsBegin = 3011,
            LoadAnnotationsEnd = 3012,
            AddAnnotationBegin = 3013,
            AddAnnotationEnd = 3014,
            DeleteAnnotationBegin = 3015,
            DeleteAnnotationEnd = 3016,
            GetAnnotationByIdBegin = 3017,
            GetAnnotationByIdEnd = 3018,
            GetAnnotationByLocBegin = 3019,
            GetAnnotationByLocEnd = 3020,
            GetAnnotationsBegin = 3021,
            GetAnnotationsEnd = 3022,
            SerializeAnnotationBegin = 3023,
            SerializeAnnotationEnd = 3024,
            DeserializeAnnotationBegin = 3025,
            DeserializeAnnotationEnd = 3026,
            UpdateAnnotationWithSNCBegin = 3027,
            UpdateAnnotationWithSNCEnd = 3028,
            UpdateSNCWithAnnotationBegin = 3029,
            UpdateSNCWithAnnotationEnd = 3030,
            AnnotationTextChangedBegin = 3031,
            AnnotationTextChangedEnd = 3032,
            AnnotationInkChangedBegin = 3033,
            AnnotationInkChangedEnd = 3034,
            AddAttachedSNBegin = 3035,
            AddAttachedSNEnd = 3036,
            RemoveAttachedSNBegin = 3037,
            RemoveAttachedSNEnd = 3038,
            AddAttachedHighlightBegin = 3039,
            AddAttachedHighlightEnd = 3040,
            RemoveAttachedHighlightBegin = 3041,
            RemoveAttachedHighlightEnd = 3042,
            AddAttachedMHBegin = 3043,
            AddAttachedMHEnd = 3044,
            RemoveAttachedMHBegin = 3045,
            RemoveAttachedMHEnd = 3046,
            WClientParseBamlBegin = 4001,
            WClientParseBamlEnd = 4002,
            WClientParseXmlBegin = 4003,
            WClientParseXmlEnd = 4004,
            WClientParseFefCrInstBegin = 4005,
            WClientParseFefCrInstEnd = 4006,
            WClientParseInstVisTreeBegin = 4007,
            WClientParseInstVisTreeEnd = 4008,
            WClientParseRdrCrInstBegin = 4009,
            WClientParseRdrCrInstEnd = 4010,
            WClientParseRdrCrInFTypBegin = 4011,
            WClientParseRdrCrInFTypEnd = 4012,
            WClientResourceFindBegin = 4013,
            WClientResourceFindEnd = 4014,
            WClientResourceCacheValue = 4015,
            WClientResourceCacheNull = 4016,
            WClientResourceCacheMiss = 4017,
            WClientResourceStock = 4018,
            WClientResourceBamlAssembly = 4019,
            WClientParseXamlBegin = 4020,
            WClientParseXamlBamlInfo = 4021,
            WClientParseXamlEnd = 4022,
            WClientDRXFlushPageStart = 5001,
            WClientDRXFlushPageStop = 5002,
            WClientDRXSerializeTreeStart = 5003,
            WClientDRXSerializeTreeEnd = 5004,
            WClientDRXGetVisualStart = 5005,
            WClientDRXGetVisualEnd = 5006,
            WClientDRXReleaseWriterStart = 5007,
            WClientDRXReleaseWriterEnd = 5008,
            WClientDRXGetPrintCapStart = 5009,
            WClientDRXGetPrintCapEnd = 5010,
            WClientDRXPTProviderStart = 5011,
            WClientDRXPTProviderEnd = 5012,
            WClientDRXRasterStart = 5013,
            WClientDRXRasterEnd = 5014,
            WClientDRXOpenPackageBegin = 5015,
            WClientDRXOpenPackageEnd = 5016,
            WClientDRXGetStreamBegin = 5017,
            WClientDRXGetStreamEnd = 5018,
            WClientDRXPageVisible = 5019,
            WClientDRXPageLoaded = 5020,
            WClientDRXInvalidateView = 5021,
            WClientDRXStyleCreated = 5022,
            WClientDRXFindBegin = 5023,
            WClientDRXFindEnd = 5024,
            WClientDRXZoom = 5025,
            WClientDRXEnsureOMBegin = 5026,
            WClientDRXEnsureOMEnd = 5027,
            WClientDRXTreeFlattenBegin = 5028,
            WClientDRXTreeFlattenEnd = 5029,
            WClientDRXAlphaFlattenBegin = 5030,
            WClientDRXAlphaFlattenEnd = 5031,
            WClientDRXGetDevModeBegin = 5032,
            WClientDRXGetDevModeEnd = 5033,
            WClientDRXStartDocBegin = 5034,
            WClientDRXStartDocEnd = 5035,
            WClientDRXEndDocBegin = 5036,
            WClientDRXEndDocEnd = 5037,
            WClientDRXStartPageBegin = 5038,
            WClientDRXStartPageEnd = 5039,
            WClientDRXEndPageBegin = 5040,
            WClientDRXEndPageEnd = 5041,
            WClientDRXCommitPageBegin = 5042,
            WClientDRXCommitPageEnd = 5043,
            WClientDRXConvertFontBegin = 5044,
            WClientDRXConvertFontEnd = 5045,
            WClientDRXConvertImageBegin = 5046,
            WClientDRXConvertImageEnd = 5047,
            WClientDRXSaveXpsBegin = 5048,
            WClientDRXSaveXpsEnd = 5049,
            WClientDRXLoadPrimitiveBegin = 5050,
            WClientDRXLoadPrimitiveEnd = 5051,
            WClientDRXSavePageBegin = 5052,
            WClientDRXSavePageEnd = 5053,
            WClientDRXSerializationBegin = 5054,
            WClientDRXSerializationEnd = 5055,
            WClientDRXReadStreamBegin = 5056,
            WClientDRXReadStreamEnd = 5057,
            WClientDRXGetPageBegin = 5058,
            WClientDRXGetPageEnd = 5059,
            WClientDRXLineDown = 5060,
            WClientDRXPageDown = 5061,
            WClientDRXPageJump = 5062,
            WClientDRXLayoutBegin = 5063,
            WClientDRXLayoutEnd = 5064,
            WClientDRXInstantiated = 5065,
            WClientTimeManagerTickBegin = 6001,
            WClientTimeManagerTickEnd = 6002,
            WClientLayoutBegin = 7001,
            WClientLayoutEnd = 7002,
            WClientMeasureBegin = 7005,
            WClientMeasureAbort = 7006,
            WClientMeasureEnd = 7007,
            WClientMeasureElementBegin = 7008,
            WClientMeasureElementEnd = 7009,
            WClientArrangeBegin = 7010,
            WClientArrangeAbort = 7011,
            WClientArrangeEnd = 7012,
            WClientArrangeElementBegin = 7013,
            WClientArrangeElementEnd = 7014,
            WClientLayoutAbort = 7015,
            WClientLayoutFireSizeChangedBegin = 7016,
            WClientLayoutFireSizeChangedEnd = 7017,
            WClientLayoutFireLayoutUpdatedBegin = 7018,
            WClientLayoutFireLayoutUpdatedEnd = 7019,
            WClientLayoutFireAutomationEventsBegin = 7020,
            WClientLayoutFireAutomationEventsEnd = 7021,
            WClientLayoutException = 7022,
            WClientLayoutInvalidated = 7023,
            WpfHostUm_WinMainStart = 9003,
            WpfHostUm_WinMainEnd = 9004,
            WpfHostUm_InvokingBrowser = 9005,
            WpfHostUm_LaunchingRestrictedProcess = 9006,
            WpfHostUm_EnteringMessageLoop = 9007,
            WpfHostUm_ClassFactoryCreateInstance = 9008,
            WpfHostUm_ReadingDeplManifestStart = 9009,
            WpfHostUm_ReadingDeplManifestEnd = 9010,
            WpfHostUm_ReadingAppManifestStart = 9011,
            WpfHostUm_ReadingAppManifestEnd = 9012,
            WpfHostUm_ParsingMarkupVersionStart = 9013,
            WpfHostUm_ParsingMarkupVersionEnd = 9014,
            WpfHostUm_IPersistFileLoad = 9015,
            WpfHostUm_IPersistMonikerLoadStart = 9016,
            WpfHostUm_IPersistMonikerLoadEnd = 9017,
            WpfHostUm_BindProgress = 9018,
            WpfHostUm_OnStopBinding = 9019,
            WpfHostUm_VersionAttach = 9020,
            WpfHostUm_VersionActivateStart = 9021,
            WpfHostUm_VersionActivateEnd = 9022,
            WpfHostUm_StartingCLRStart = 9023,
            WpfHostUm_StartingCLREnd = 9024,
            WpfHostUm_IHlinkTargetNavigateStart = 9025,
            WpfHostUm_IHlinkTargetNavigateEnd = 9026,
            WpfHostUm_ReadyStateChanged = 9027,
            WpfHostUm_InitDocHostStart = 9028,
            WpfHostUm_InitDocHostEnd = 9029,
            WpfHostUm_MergingMenusStart = 9030,
            WpfHostUm_MergingMenusEnd = 9031,
            WpfHostUm_UIActivationStart = 9032,
            WpfHostUm_UIActivationEnd = 9033,
            WpfHostUm_LoadingResourceDLLStart = 9034,
            WpfHostUm_LoadingResourceDLLEnd = 9035,
            WpfHostUm_OleCmdQueryStatusStart = 9036,
            WpfHostUm_OleCmdQueryStatusEnd = 9037,
            WpfHostUm_OleCmdExecStart = 9038,
            WpfHostUm_OleCmdExecEnd = 9039,
            WpfHostUm_ProgressPageShown = 9040,
            WpfHostUm_AdHocProfile1Start = 9041,
            WpfHostUm_AdHocProfile1End = 9042,
            WpfHostUm_AdHocProfile2Start = 9043,
            WpfHostUm_AdHocProfile2End = 9044,
            WpfHost_DocObjHostCreated = 9045,
            WpfHost_XappLauncherAppStartup = 9046,
            WpfHost_XappLauncherAppExit = 9047,
            WpfHost_DocObjHostRunApplicationStart = 9048,
            WpfHost_DocObjHostRunApplicationEnd = 9049,
            WpfHost_ClickOnceActivationStart = 9050,
            WpfHost_ClickOnceActivationEnd = 9051,
            WpfHost_InitAppProxyStart = 9052,
            WpfHost_InitAppProxyEnd = 9053,
            WpfHost_AppProxyCtor = 9054,
            WpfHost_RootBrowserWindowSetupStart = 9055,
            WpfHost_RootBrowserWindowSetupEnd = 9056,
            WpfHost_AppProxyRunStart = 9057,
            WpfHost_AppProxyRunEnd = 9058,
            WpfHost_AppDomainManagerCctor = 9059,
            WpfHost_ApplicationActivatorCreateInstanceStart = 9060,
            WpfHost_ApplicationActivatorCreateInstanceEnd = 9061,
            WpfHost_DetermineApplicationTrustStart = 9062,
            WpfHost_DetermineApplicationTrustEnd = 9063,
            WpfHost_FirstTimeActivation = 9064,
            WpfHost_GetDownloadPageStart = 9065,
            WpfHost_GetDownloadPageEnd = 9066,
            WpfHost_DownloadDeplManifestStart = 9067,
            WpfHost_DownloadDeplManifestEnd = 9068,
            WpfHost_AssertAppRequirementsStart = 9069,
            WpfHost_AssertAppRequirementsEnd = 9070,
            WpfHost_DownloadApplicationStart = 9071,
            WpfHost_DownloadApplicationEnd = 9072,
            WpfHost_DownloadProgressUpdate = 9073,
            WpfHost_XappLauncherAppNavigated = 9074,
            WpfHost_UpdateBrowserCommandsStart = 9077,
            WpfHost_UpdateBrowserCommandsEnd = 9078,
            WpfHost_PostShutdown = 9079,
            WpfHost_AbortingActivation = 9080,
            WpfHost_IBHSRunStart = 9081,
            WpfHost_IBHSRunEnd = 9082,
            Wpf_NavigationAsyncWorkItem = 9083,
            Wpf_NavigationWebResponseReceived = 9084,
            Wpf_NavigationEnd = 9085,
            Wpf_NavigationContentRendered = 9086,
            Wpf_NavigationStart = 9087,
            Wpf_NavigationLaunchBrowser = 9088,
            Wpf_NavigationPageFunctionReturn = 9089,
            DrawBitmapInfo = 11001,
            BitmapCopyInfo = 11002,
            SetClipInfo = 11003,
            DWMDraw_ClearStart = 11004,
            DWMDraw_ClearEnd = 11005,
            DWMDraw_BitmapStart = 11006,
            DWMDraw_BitmapEnd = 11007,
            DWMDraw_RectangleStart = 11008,
            DWMDraw_RectangleEnd = 11009,
            DWMDraw_GeometryStart = 11010,
            DWMDraw_GeometryEnd = 11011,
            DWMDraw_ImageStart = 11012,
            DWMDraw_ImageEnd = 11013,
            DWMDraw_GlyphRunStart = 11014,
            DWMDraw_GlyphRunEnd = 11015,
            DWMDraw_BeginLayerStart = 11016,
            DWMDraw_BeginLayerEnd = 11017,
            DWMDraw_EndLayerStart = 11018,
            DWMDraw_EndLayerEnd = 11019,
            DWMDraw_ClippedBitmapStart = 11020,
            DWMDraw_ClippedBitmapEnd = 11021,
            DWMDraw_Info = 11022,
            LayerEventStart = 11023,
            LayerEventEnd = 11024,
            WClientDesktopRTCreateBegin = 11025,
            WClientDesktopRTCreateEnd = 11026,
            WClientUceProcessQueueBegin = 11027,
            WClientUceProcessQueueEnd = 11028,
            WClientUceProcessQueueInfo = 11029,
            WClientUcePrecomputeBegin = 11030,
            WClientUcePrecomputeEnd = 11031,
            WClientUceRenderBegin = 11032,
            WClientUceRenderEnd = 11033,
            WClientUcePresentBegin = 11034,
            WClientUcePresentEnd = 11035,
            WClientUceResponse = 11036,
            WClientUceCheckDeviceStateInfo = 11037,
            VisualCacheAlloc = 11038,
            VisualCacheUpdate = 11039,
            CreateChannel = 11040,
            CreateOrAddResourceOnChannel = 11041,
            CreateWpfGfxResource = 11042,
            ReleaseOnChannel = 11043,
            UnexpectedSoftwareFallback = 11044,
            WClientInterlockedRenderBegin = 11045,
            WClientInterlockedRenderEnd = 11046,
            WClientRenderHandlerBegin = 11047,
            WClientRenderHandlerEnd = 11048,
            WClientAnimRenderHandlerBegin = 11049,
            WClientAnimRenderHandlerEnd = 11050,
            WClientMediaRenderBegin = 11051,
            WClientMediaRenderEnd = 11052,
            WClientPostRender = 11053,
            WClientQPCFrequency = 11054,
            WClientPrecomputeSceneBegin = 11055,
            WClientPrecomputeSceneEnd = 11056,
            WClientCompileSceneBegin = 11057,
            WClientCompileSceneEnd = 11058,
            WClientUIResponse = 11059,
            WClientUICommitChannel = 11060,
            WClientUceNotifyPresent = 11061,
            WClientScheduleRender = 11062,
            WClientOnRenderBegin = 11063,
            WClientOnRenderEnd = 11064,
            WClientCreateIRT = 11065,
            WClientPotentialIRTResource = 11066,
            WClientUIContextDispatchBegin = 12001,
            WClientUIContextDispatchEnd = 12002,
            WClientUIContextPost = 12003,
            WClientUIContextAbort = 12004,
            WClientUIContextPromote = 12005,
            WClientUIContextIdle = 12006,
        }

        internal static Guid GetGuidForEvent(Event arg)
        {
            switch (arg)
            {
                case Event.WClientCreateVisual:
                    // 2dbecf62-51ea-493a-8dd0-4bee1ccbe8aa
                    return new Guid(0x2DBECF62, 0x51EA, 0x493A, 0x8D, 0xD0, 0x4B, 0xEE, 0x1C, 0xCB, 0xE8, 0xAA);
                case Event.WClientAppCtor:
                    // f9f048c6-2011-4d0a-812a-23a4a4d801f5
                    return new Guid(0xF9F048C6, 0x2011, 0x4D0A, 0x81, 0x2A, 0x23, 0xA4, 0xA4, 0xD8, 0x1, 0xF5);
                case Event.WClientAppRun:
                    // 08a719d6-ea79-4abc-9799-38eded602133
                    return new Guid(0x8A719D6, 0xEA79, 0x4ABC, 0x97, 0x99, 0x38, 0xED, 0xED, 0x60, 0x21, 0x33);
                case Event.WClientString:
                case Event.WClientStringBegin:
                case Event.WClientStringEnd:
                    // 6b3c0258-9ddb-4579-8660-41c3ada25c34
                    return new Guid(0x6B3C0258, 0x9DDB, 0x4579, 0x86, 0x60, 0x41, 0xC3, 0xAD, 0xA2, 0x5C, 0x34);
                case Event.WClientPropParentCheck:
                    // 831bea07-5a2c-434c-8ef8-7eba41c881fb
                    return new Guid(0x831BEA07, 0x5A2C, 0x434C, 0x8E, 0xF8, 0x7E, 0xBA, 0x41, 0xC8, 0x81, 0xFB);
                case Event.UpdateVisualStateStart:
                case Event.UpdateVisualStateEnd:
                    // 07a7dd63-b52d-4eff-ac3f-2448daf97499
                    return new Guid(0x7A7DD63, 0xB52D, 0x4EFF, 0xAC, 0x3F, 0x24, 0x48, 0xDA, 0xF9, 0x74, 0x99);
                case Event.PerfElementIDName:
                case Event.PerfElementIDAssignment:
                    // a060d980-4c18-4953-81df-cfdfd345c5ca
                    return new Guid(0xA060D980, 0x4C18, 0x4953, 0x81, 0xDF, 0xCF, 0xDF, 0xD3, 0x45, 0xC5, 0xCA);
                case Event.WClientFontCache:
                    // f3362106-b861-4980-9aac-b1ef0bab75aa
                    return new Guid(0xF3362106, 0xB861, 0x4980, 0x9A, 0xAC, 0xB1, 0xEF, 0xB, 0xAB, 0x75, 0xAA);
                case Event.WClientInputMessage:
                    // 4ac79bac-7dfb-4402-a910-fdafe16f29b2
                    return new Guid(0x4AC79BAC, 0x7DFB, 0x4402, 0xA9, 0x10, 0xFD, 0xAF, 0xE1, 0x6F, 0x29, 0xB2);
                case Event.StylusEventQueued:
                    // 41ecd0f8-f5a6-4aae-9e85-caece119b853
                    return new Guid(0x41ECD0F8, 0xF5A6, 0x4AAE, 0x9E, 0x85, 0xCA, 0xEC, 0xE1, 0x19, 0xB8, 0x53);
                case Event.TouchDownReported:
                    // 837ad37a-8cef-4c0c-944a-ae3b1f1c2557
                    return new Guid(0x837AD37A, 0x8CEF, 0x4C0C, 0x94, 0x4A, 0xAE, 0x3B, 0x1F, 0x1C, 0x25, 0x57);
                case Event.TouchMoveReported:
                    // fd718e3f-5462-4227-a610-75d5bf8967a2
                    return new Guid(0xFD718E3F, 0x5462, 0x4227, 0xA6, 0x10, 0x75, 0xD5, 0xBF, 0x89, 0x67, 0xA2);
                case Event.TouchUpReported:
                    // c2ac85a3-e16b-4d07-90de-1e686394b831
                    return new Guid(0xC2AC85A3, 0xE16B, 0x4D07, 0x90, 0xDE, 0x1E, 0x68, 0x63, 0x94, 0xB8, 0x31);
                case Event.ManipulationReportFrame:
                    // e185d096-6eb9-41be-81f4-75d924425872
                    return new Guid(0xE185D096, 0x6EB9, 0x41BE, 0x81, 0xF4, 0x75, 0xD9, 0x24, 0x42, 0x58, 0x72);
                case Event.ManipulationEventRaised:
                    // 51f685eb-b111-400d-b3e3-46022f66a894
                    return new Guid(0x51F685EB, 0xB111, 0x400D, 0xB3, 0xE3, 0x46, 0x2, 0x2F, 0x66, 0xA8, 0x94);
                case Event.PenThreadPoolThreadAcquisition:
                    // 6c325c36-4d5f-4328-b1c6-e164796dfe2b
                    return new Guid(0x6C325C36, 0x4D5F, 0x4328, 0xB1, 0xC6, 0xE1, 0x64, 0x79, 0x6D, 0xFE, 0x2B);
                case Event.CreateStickyNoteBegin:
                case Event.CreateStickyNoteEnd:
                    // e3dbffac-1e92-4f48-a65a-c290bd5f5f15
                    return new Guid(0xE3DBFFAC, 0x1E92, 0x4F48, 0xA6, 0x5A, 0xC2, 0x90, 0xBD, 0x5F, 0x5F, 0x15);
                case Event.DeleteTextNoteBegin:
                case Event.DeleteTextNoteEnd:
                    // 7626a2f9-9a61-43a3-b7cc-bb84c2493aa7
                    return new Guid(0x7626A2F9, 0x9A61, 0x43A3, 0xB7, 0xCC, 0xBB, 0x84, 0xC2, 0x49, 0x3A, 0xA7);
                case Event.DeleteInkNoteBegin:
                case Event.DeleteInkNoteEnd:
                    // bf7e2a93-9d6a-453e-badb-3f8f60075cf2
                    return new Guid(0xBF7E2A93, 0x9D6A, 0x453E, 0xBA, 0xDB, 0x3F, 0x8F, 0x60, 0x7, 0x5C, 0xF2);
                case Event.CreateHighlightBegin:
                case Event.CreateHighlightEnd:
                    // c2a5edb8-ac73-41ef-a943-a8a49fa284b1
                    return new Guid(0xC2A5EDB8, 0xAC73, 0x41EF, 0xA9, 0x43, 0xA8, 0xA4, 0x9F, 0xA2, 0x84, 0xB1);
                case Event.ClearHighlightBegin:
                case Event.ClearHighlightEnd:
                    // e1a59147-d28d-4c5f-b980-691be2fd4208
                    return new Guid(0xE1A59147, 0xD28D, 0x4C5F, 0xB9, 0x80, 0x69, 0x1B, 0xE2, 0xFD, 0x42, 0x8);
                case Event.LoadAnnotationsBegin:
                case Event.LoadAnnotationsEnd:
                    // cf3a283e-c004-4e7d-b3b9-cc9b582a4a5f
                    return new Guid(0xCF3A283E, 0xC004, 0x4E7D, 0xB3, 0xB9, 0xCC, 0x9B, 0x58, 0x2A, 0x4A, 0x5F);
                case Event.AddAnnotationBegin:
                case Event.AddAnnotationEnd:
                    // 8f4b2faa-24d6-4ee2-9935-bbf845f758a2
                    return new Guid(0x8F4B2FAA, 0x24D6, 0x4EE2, 0x99, 0x35, 0xBB, 0xF8, 0x45, 0xF7, 0x58, 0xA2);
                case Event.DeleteAnnotationBegin:
                case Event.DeleteAnnotationEnd:
                    // 4d832230-952a-4464-80af-aab2ac861703
                    return new Guid(0x4D832230, 0x952A, 0x4464, 0x80, 0xAF, 0xAA, 0xB2, 0xAC, 0x86, 0x17, 0x3);
                case Event.GetAnnotationByIdBegin:
                case Event.GetAnnotationByIdEnd:
                    // 3d27753f-eb8a-4e75-9d5b-82fba55cded1
                    return new Guid(0x3D27753F, 0xEB8A, 0x4E75, 0x9D, 0x5B, 0x82, 0xFB, 0xA5, 0x5C, 0xDE, 0xD1);
                case Event.GetAnnotationByLocBegin:
                case Event.GetAnnotationByLocEnd:
                    // 741a41bc-8ecd-43d1-a7f1-d2faca7362ef
                    return new Guid(0x741A41BC, 0x8ECD, 0x43D1, 0xA7, 0xF1, 0xD2, 0xFA, 0xCA, 0x73, 0x62, 0xEF);
                case Event.GetAnnotationsBegin:
                case Event.GetAnnotationsEnd:
                    // cd9f6017-7e64-4c61-b9ed-5c2fc8c4d849
                    return new Guid(0xCD9F6017, 0x7E64, 0x4C61, 0xB9, 0xED, 0x5C, 0x2F, 0xC8, 0xC4, 0xD8, 0x49);
                case Event.SerializeAnnotationBegin:
                case Event.SerializeAnnotationEnd:
                    // 0148924b-5bea-43e9-b3ed-399ca13b35eb
                    return new Guid(0x148924B, 0x5BEA, 0x43E9, 0xB3, 0xED, 0x39, 0x9C, 0xA1, 0x3B, 0x35, 0xEB);
                case Event.DeserializeAnnotationBegin:
                case Event.DeserializeAnnotationEnd:
                    // 2e32c255-d6db-4de7-9e62-9586377778d5
                    return new Guid(0x2E32C255, 0xD6DB, 0x4DE7, 0x9E, 0x62, 0x95, 0x86, 0x37, 0x77, 0x78, 0xD5);
                case Event.UpdateAnnotationWithSNCBegin:
                case Event.UpdateAnnotationWithSNCEnd:
                    // 205e0a58-3c7d-495d-b3ed-18c3fb38923f
                    return new Guid(0x205E0A58, 0x3C7D, 0x495D, 0xB3, 0xED, 0x18, 0xC3, 0xFB, 0x38, 0x92, 0x3F);
                case Event.UpdateSNCWithAnnotationBegin:
                case Event.UpdateSNCWithAnnotationEnd:
                    // 59c337ce-9cc2-4a86-9bfa-061fe954086b
                    return new Guid(0x59C337CE, 0x9CC2, 0x4A86, 0x9B, 0xFA, 0x6, 0x1F, 0xE9, 0x54, 0x8, 0x6B);
                case Event.AnnotationTextChangedBegin:
                case Event.AnnotationTextChangedEnd:
                    // 8bb912b9-39dd-4208-ad62-be66fe5b7ba5
                    return new Guid(0x8BB912B9, 0x39DD, 0x4208, 0xAD, 0x62, 0xBE, 0x66, 0xFE, 0x5B, 0x7B, 0xA5);
                case Event.AnnotationInkChangedBegin:
                case Event.AnnotationInkChangedEnd:
                    // 1228e154-f171-426e-b672-5ee19b755edf
                    return new Guid(0x1228E154, 0xF171, 0x426E, 0xB6, 0x72, 0x5E, 0xE1, 0x9B, 0x75, 0x5E, 0xDF);
                case Event.AddAttachedSNBegin:
                case Event.AddAttachedSNEnd:
                    // 9ca660f6-8d7c-4a90-a92f-74482d9cc1cf
                    return new Guid(0x9CA660F6, 0x8D7C, 0x4A90, 0xA9, 0x2F, 0x74, 0x48, 0x2D, 0x9C, 0xC1, 0xCF);
                case Event.RemoveAttachedSNBegin:
                case Event.RemoveAttachedSNEnd:
                    // 8c4c69f7-1185-46df-a5f5-e31ac7e96c07
                    return new Guid(0x8C4C69F7, 0x1185, 0x46DF, 0xA5, 0xF5, 0xE3, 0x1A, 0xC7, 0xE9, 0x6C, 0x7);
                case Event.AddAttachedHighlightBegin:
                case Event.AddAttachedHighlightEnd:
                    // 56d2cae5-5ec0-44fb-98c2-453e87a0877b
                    return new Guid(0x56D2CAE5, 0x5EC0, 0x44FB, 0x98, 0xC2, 0x45, 0x3E, 0x87, 0xA0, 0x87, 0x7B);
                case Event.RemoveAttachedHighlightBegin:
                case Event.RemoveAttachedHighlightEnd:
                    // 4c81d490-9004-49d1-87d7-289d53a314ef
                    return new Guid(0x4C81D490, 0x9004, 0x49D1, 0x87, 0xD7, 0x28, 0x9D, 0x53, 0xA3, 0x14, 0xEF);
                case Event.AddAttachedMHBegin:
                case Event.AddAttachedMHEnd:
                    // 7ea1d548-ca17-ca17-a1a8-f1857db6302e
                    return new Guid(0x7EA1D548, 0xCA17, 0xCA17, 0xA1, 0xA8, 0xF1, 0x85, 0x7D, 0xB6, 0x30, 0x2E);
                case Event.RemoveAttachedMHBegin:
                case Event.RemoveAttachedMHEnd:
                    // 296c7961-b975-450b-8975-bf862b6c7159
                    return new Guid(0x296C7961, 0xB975, 0x450B, 0x89, 0x75, 0xBF, 0x86, 0x2B, 0x6C, 0x71, 0x59);
                case Event.WClientParseBamlBegin:
                case Event.WClientParseBamlEnd:
                    // 8a1e3af5-3a6d-4582-86d1-5901471ebbde
                    return new Guid(0x8A1E3AF5, 0x3A6D, 0x4582, 0x86, 0xD1, 0x59, 0x1, 0x47, 0x1E, 0xBB, 0xDE);
                case Event.WClientParseXmlBegin:
                case Event.WClientParseXmlEnd:
                    // bf86e5bf-3fb4-442f-a34a-b207a3b19c3b
                    return new Guid(0xBF86E5BF, 0x3FB4, 0x442F, 0xA3, 0x4A, 0xB2, 0x7, 0xA3, 0xB1, 0x9C, 0x3B);
                case Event.WClientParseFefCrInstBegin:
                case Event.WClientParseFefCrInstEnd:
                    // f7555161-6c1a-4a12-828d-8492a7699a49
                    return new Guid(0xF7555161, 0x6C1A, 0x4A12, 0x82, 0x8D, 0x84, 0x92, 0xA7, 0x69, 0x9A, 0x49);
                case Event.WClientParseInstVisTreeBegin:
                case Event.WClientParseInstVisTreeEnd:
                    // a8c3b9c0-562b-4509-becb-a08e481a7273
                    return new Guid(0xA8C3B9C0, 0x562B, 0x4509, 0xBE, 0xCB, 0xA0, 0x8E, 0x48, 0x1A, 0x72, 0x73);
                case Event.WClientParseRdrCrInstBegin:
                case Event.WClientParseRdrCrInstEnd:
                    // 8ba8f51c-0775-4adf-9eed-b1654ca088f5
                    return new Guid(0x8BA8F51C, 0x775, 0x4ADF, 0x9E, 0xED, 0xB1, 0x65, 0x4C, 0xA0, 0x88, 0xF5);
                case Event.WClientParseRdrCrInFTypBegin:
                case Event.WClientParseRdrCrInFTypEnd:
                    // 0da15d58-c3a7-40de-9113-72db0c4a9351
                    return new Guid(0xDA15D58, 0xC3A7, 0x40DE, 0x91, 0x13, 0x72, 0xDB, 0xC, 0x4A, 0x93, 0x51);
                case Event.WClientResourceFindBegin:
                case Event.WClientResourceFindEnd:
                    // 228d90d5-7e19-4480-9e56-3af2e90f8da6
                    return new Guid(0x228D90D5, 0x7E19, 0x4480, 0x9E, 0x56, 0x3A, 0xF2, 0xE9, 0xF, 0x8D, 0xA6);
                case Event.WClientResourceCacheValue:
                    // 3b253e2d-72a5-489e-8c65-56c1e6c859b5
                    return new Guid(0x3B253E2D, 0x72A5, 0x489E, 0x8C, 0x65, 0x56, 0xC1, 0xE6, 0xC8, 0x59, 0xB5);
                case Event.WClientResourceCacheNull:
                    // 7866a65b-2f38-43b6-abd2-df433bbca073
                    return new Guid(0x7866A65B, 0x2F38, 0x43B6, 0xAB, 0xD2, 0xDF, 0x43, 0x3B, 0xBC, 0xA0, 0x73);
                case Event.WClientResourceCacheMiss:
                    // 0420755f-d416-4f15-939f-3e2cd3fcea23
                    return new Guid(0x420755F, 0xD416, 0x4F15, 0x93, 0x9F, 0x3E, 0x2C, 0xD3, 0xFC, 0xEA, 0x23);
                case Event.WClientResourceStock:
                    // 06f0fee4-72dd-4802-bd3d-0985139fa91a
                    return new Guid(0x6F0FEE4, 0x72DD, 0x4802, 0xBD, 0x3D, 0x9, 0x85, 0x13, 0x9F, 0xA9, 0x1A);
                case Event.WClientResourceBamlAssembly:
                    // 19df4373-6680-4a04-8c77-d2f6809ca703
                    return new Guid(0x19DF4373, 0x6680, 0x4A04, 0x8C, 0x77, 0xD2, 0xF6, 0x80, 0x9C, 0xA7, 0x3);
                case Event.WClientParseXamlBegin:
                    // 3164257a-c9be-4c36-9d8f-09b18ac880a6
                    return new Guid(0x3164257A, 0xC9BE, 0x4C36, 0x9D, 0x8F, 0x9, 0xB1, 0x8A, 0xC8, 0x80, 0xA6);
                case Event.WClientParseXamlBamlInfo:
                    // 00c117d0-8234-4efa-ace3-73ba1c655f28
                    return new Guid(0xC117D0, 0x8234, 0x4EFA, 0xAC, 0xE3, 0x73, 0xBA, 0x1C, 0x65, 0x5F, 0x28);
                case Event.WClientParseXamlEnd:
                    // 3164257a-c9be-4c36-9d8f-09b18ac880a6
                    return new Guid(0x3164257A, 0xC9BE, 0x4C36, 0x9D, 0x8F, 0x9, 0xB1, 0x8A, 0xC8, 0x80, 0xA6);
                case Event.WClientDRXFlushPageStart:
                case Event.WClientDRXFlushPageStop:
                    // 5303d552-28ab-4dac-8bcd-0f7d5675a158
                    return new Guid(0x5303D552, 0x28AB, 0x4DAC, 0x8B, 0xCD, 0xF, 0x7D, 0x56, 0x75, 0xA1, 0x58);
                case Event.WClientDRXSerializeTreeStart:
                case Event.WClientDRXSerializeTreeEnd:
                    // 5303d552-28ab-4dac-8bcd-0f7d5675a15a
                    return new Guid(0x5303D552, 0x28AB, 0x4DAC, 0x8B, 0xCD, 0xF, 0x7D, 0x56, 0x75, 0xA1, 0x5A);
                case Event.WClientDRXGetVisualStart:
                case Event.WClientDRXGetVisualEnd:
                    // 5303d552-28ab-4dac-8bcd-0f7d5675a159
                    return new Guid(0x5303D552, 0x28AB, 0x4DAC, 0x8B, 0xCD, 0xF, 0x7D, 0x56, 0x75, 0xA1, 0x59);
                case Event.WClientDRXReleaseWriterStart:
                case Event.WClientDRXReleaseWriterEnd:
                    // 5303d552-28ab-4dac-8bcd-0f7d5675a15b
                    return new Guid(0x5303D552, 0x28AB, 0x4DAC, 0x8B, 0xCD, 0xF, 0x7D, 0x56, 0x75, 0xA1, 0x5B);
                case Event.WClientDRXGetPrintCapStart:
                case Event.WClientDRXGetPrintCapEnd:
                    // 5303d552-28ab-4dac-8bcd-0f7d5675a15c
                    return new Guid(0x5303D552, 0x28AB, 0x4DAC, 0x8B, 0xCD, 0xF, 0x7D, 0x56, 0x75, 0xA1, 0x5C);
                case Event.WClientDRXPTProviderStart:
                case Event.WClientDRXPTProviderEnd:
                    // 5303d552-28ab-4dac-8bcd-0f7d5675a15d
                    return new Guid(0x5303D552, 0x28AB, 0x4DAC, 0x8B, 0xCD, 0xF, 0x7D, 0x56, 0x75, 0xA1, 0x5D);
                case Event.WClientDRXRasterStart:
                case Event.WClientDRXRasterEnd:
                    // 5303d552-28ab-4dac-8bcd-0f7d5675a15e
                    return new Guid(0x5303D552, 0x28AB, 0x4DAC, 0x8B, 0xCD, 0xF, 0x7D, 0x56, 0x75, 0xA1, 0x5E);
                case Event.WClientDRXOpenPackageBegin:
                case Event.WClientDRXOpenPackageEnd:
                    // 2b8f75f3-f8f9-4075-b914-5ae853c76276
                    return new Guid(0x2B8F75F3, 0xF8F9, 0x4075, 0xB9, 0x14, 0x5A, 0xE8, 0x53, 0xC7, 0x62, 0x76);
                case Event.WClientDRXGetStreamBegin:
                case Event.WClientDRXGetStreamEnd:
                    // 3f4510eb-9ee8-4b80-9ec7-775efeb1ba72
                    return new Guid(0x3F4510EB, 0x9EE8, 0x4B80, 0x9E, 0xC7, 0x77, 0x5E, 0xFE, 0xB1, 0xBA, 0x72);
                case Event.WClientDRXPageVisible:
                    // 2ae7c601-0aec-4c99-ba80-2eca712d1b97
                    return new Guid(0x2AE7C601, 0xAEC, 0x4C99, 0xBA, 0x80, 0x2E, 0xCA, 0x71, 0x2D, 0x1B, 0x97);
                case Event.WClientDRXPageLoaded:
                    // 66028645-e022-4d90-a7bd-a8ccdacdb2e1
                    return new Guid(0x66028645, 0xE022, 0x4D90, 0xA7, 0xBD, 0xA8, 0xCC, 0xDA, 0xCD, 0xB2, 0xE1);
                case Event.WClientDRXInvalidateView:
                    // 3be3740f-0a31-4d22-a2a3-4d4b6d3ab899
                    return new Guid(0x3BE3740F, 0xA31, 0x4D22, 0xA2, 0xA3, 0x4D, 0x4B, 0x6D, 0x3A, 0xB8, 0x99);
                case Event.WClientDRXStyleCreated:
                    // 69737c35-1636-43be-a352-428ca36d1b2c
                    return new Guid(0x69737C35, 0x1636, 0x43BE, 0xA3, 0x52, 0x42, 0x8C, 0xA3, 0x6D, 0x1B, 0x2C);
                case Event.WClientDRXFindBegin:
                case Event.WClientDRXFindEnd:
                    // ff8efb74-efaa-424d-9022-ee8d21ad804e
                    return new Guid(0xFF8EFB74, 0xEFAA, 0x424D, 0x90, 0x22, 0xEE, 0x8D, 0x21, 0xAD, 0x80, 0x4E);
                case Event.WClientDRXZoom:
                    // 2e5045a1-8dac-4c90-9995-3260de166c8f
                    return new Guid(0x2E5045A1, 0x8DAC, 0x4C90, 0x99, 0x95, 0x32, 0x60, 0xDE, 0x16, 0x6C, 0x8F);
                case Event.WClientDRXEnsureOMBegin:
                case Event.WClientDRXEnsureOMEnd:
                    // 28e3a8bb-aebb-48e8-86b6-32759b47fcbe
                    return new Guid(0x28E3A8BB, 0xAEBB, 0x48E8, 0x86, 0xB6, 0x32, 0x75, 0x9B, 0x47, 0xFC, 0xBE);
                case Event.WClientDRXTreeFlattenBegin:
                case Event.WClientDRXTreeFlattenEnd:
                    // b4557454-212b-4f57-b9ca-2ba9d58273b3
                    return new Guid(0xB4557454, 0x212B, 0x4F57, 0xB9, 0xCA, 0x2B, 0xA9, 0xD5, 0x82, 0x73, 0xB3);
                case Event.WClientDRXAlphaFlattenBegin:
                case Event.WClientDRXAlphaFlattenEnd:
                    // 302f02e9-f025-4083-abd5-2ce3aaa9a3cf
                    return new Guid(0x302F02E9, 0xF025, 0x4083, 0xAB, 0xD5, 0x2C, 0xE3, 0xAA, 0xA9, 0xA3, 0xCF);
                case Event.WClientDRXGetDevModeBegin:
                case Event.WClientDRXGetDevModeEnd:
                    // 573ea8dc-db6c-42c0-91f8-964e39cb6a70
                    return new Guid(0x573EA8DC, 0xDB6C, 0x42C0, 0x91, 0xF8, 0x96, 0x4E, 0x39, 0xCB, 0x6A, 0x70);
                case Event.WClientDRXStartDocBegin:
                case Event.WClientDRXStartDocEnd:
                    // f3fba666-fa0f-4487-b846-9f204811bf3d
                    return new Guid(0xF3FBA666, 0xFA0F, 0x4487, 0xB8, 0x46, 0x9F, 0x20, 0x48, 0x11, 0xBF, 0x3D);
                case Event.WClientDRXEndDocBegin:
                case Event.WClientDRXEndDocEnd:
                    // 743dd3cf-bbce-4e69-a4db-85226ec6a445
                    return new Guid(0x743DD3CF, 0xBBCE, 0x4E69, 0xA4, 0xDB, 0x85, 0x22, 0x6E, 0xC6, 0xA4, 0x45);
                case Event.WClientDRXStartPageBegin:
                case Event.WClientDRXStartPageEnd:
                    // 5303d552-28ab-4dac-8bcd-0f7d5675a157
                    return new Guid(0x5303D552, 0x28AB, 0x4DAC, 0x8B, 0xCD, 0xF, 0x7D, 0x56, 0x75, 0xA1, 0x57);
                case Event.WClientDRXEndPageBegin:
                case Event.WClientDRXEndPageEnd:
                    // e20fddf4-17a6-4e5f-8693-3dd7cb049422
                    return new Guid(0xE20FDDF4, 0x17A6, 0x4E5F, 0x86, 0x93, 0x3D, 0xD7, 0xCB, 0x4, 0x94, 0x22);
                case Event.WClientDRXCommitPageBegin:
                case Event.WClientDRXCommitPageEnd:
                    // 7d7ee18d-aea5-493f-9ef2-bbdb36fcaa78
                    return new Guid(0x7D7EE18D, 0xAEA5, 0x493F, 0x9E, 0xF2, 0xBB, 0xDB, 0x36, 0xFC, 0xAA, 0x78);
                case Event.WClientDRXConvertFontBegin:
                case Event.WClientDRXConvertFontEnd:
                    // 88fc2d42-b1de-4588-8c3b-dc5bec03a9ac
                    return new Guid(0x88FC2D42, 0xB1DE, 0x4588, 0x8C, 0x3B, 0xDC, 0x5B, 0xEC, 0x3, 0xA9, 0xAC);
                case Event.WClientDRXConvertImageBegin:
                case Event.WClientDRXConvertImageEnd:
                    // 17fddfdc-a1be-43b3-b2ee-f5e89b7b1b26
                    return new Guid(0x17FDDFDC, 0xA1BE, 0x43B3, 0xB2, 0xEE, 0xF5, 0xE8, 0x9B, 0x7B, 0x1B, 0x26);
                case Event.WClientDRXSaveXpsBegin:
                case Event.WClientDRXSaveXpsEnd:
                    // ba0320d5-2294-4067-8b19-ef9cddad4b1a
                    return new Guid(0xBA0320D5, 0x2294, 0x4067, 0x8B, 0x19, 0xEF, 0x9C, 0xDD, 0xAD, 0x4B, 0x1A);
                case Event.WClientDRXLoadPrimitiveBegin:
                case Event.WClientDRXLoadPrimitiveEnd:
                    // d0b70c99-450e-4872-a2d4-fbfb1dc797fa
                    return new Guid(0xD0B70C99, 0x450E, 0x4872, 0xA2, 0xD4, 0xFB, 0xFB, 0x1D, 0xC7, 0x97, 0xFA);
                case Event.WClientDRXSavePageBegin:
                case Event.WClientDRXSavePageEnd:
                    // b0e3e78b-9ac7-473c-8903-b5d212399e3b
                    return new Guid(0xB0E3E78B, 0x9AC7, 0x473C, 0x89, 0x3, 0xB5, 0xD2, 0x12, 0x39, 0x9E, 0x3B);
                case Event.WClientDRXSerializationBegin:
                case Event.WClientDRXSerializationEnd:
                    // 0527276c-d3f4-4293-b88c-ecdf7cac4430
                    return new Guid(0x527276C, 0xD3F4, 0x4293, 0xB8, 0x8C, 0xEC, 0xDF, 0x7C, 0xAC, 0x44, 0x30);
                case Event.WClientDRXReadStreamBegin:
                case Event.WClientDRXReadStreamEnd:
                    // c2b15025-7812-4e44-8b68-7d734303438a
                    return new Guid(0xC2B15025, 0x7812, 0x4E44, 0x8B, 0x68, 0x7D, 0x73, 0x43, 0x3, 0x43, 0x8A);
                case Event.WClientDRXGetPageBegin:
                case Event.WClientDRXGetPageEnd:
                    // a0c17259-c6b1-4850-a9ab-13659fe6dc58
                    return new Guid(0xA0C17259, 0xC6B1, 0x4850, 0xA9, 0xAB, 0x13, 0x65, 0x9F, 0xE6, 0xDC, 0x58);
                case Event.WClientDRXLineDown:
                    // b67ab12c-29bf-4020-b678-f043925b8235
                    return new Guid(0xB67AB12C, 0x29BF, 0x4020, 0xB6, 0x78, 0xF0, 0x43, 0x92, 0x5B, 0x82, 0x35);
                case Event.WClientDRXPageDown:
                    // d7cdeb52-5ba3-4e02-b114-385a61e7ba9d
                    return new Guid(0xD7CDEB52, 0x5BA3, 0x4E02, 0xB1, 0x14, 0x38, 0x5A, 0x61, 0xE7, 0xBA, 0x9D);
                case Event.WClientDRXPageJump:
                    // f068b137-7b09-44a1-84d0-4ff1592e0ac1
                    return new Guid(0xF068B137, 0x7B09, 0x44A1, 0x84, 0xD0, 0x4F, 0xF1, 0x59, 0x2E, 0xA, 0xC1);
                case Event.WClientDRXLayoutBegin:
                case Event.WClientDRXLayoutEnd:
                    // 34fbea40-0238-498f-b12a-631f5a8ef9a5
                    return new Guid(0x34FBEA40, 0x238, 0x498F, 0xB1, 0x2A, 0x63, 0x1F, 0x5A, 0x8E, 0xF9, 0xA5);
                case Event.WClientDRXInstantiated:
                    // 9de677e1-914a-426c-bcd9-2ccdea3648df
                    return new Guid(0x9DE677E1, 0x914A, 0x426C, 0xBC, 0xD9, 0x2C, 0xCD, 0xEA, 0x36, 0x48, 0xDF);
                case Event.WClientTimeManagerTickBegin:
                case Event.WClientTimeManagerTickEnd:
                    // ea3b4b66-b25f-4e5d-8bd4-ec62bb44583e
                    return new Guid(0xEA3B4B66, 0xB25F, 0x4E5D, 0x8B, 0xD4, 0xEC, 0x62, 0xBB, 0x44, 0x58, 0x3E);
                case Event.WClientLayoutBegin:
                case Event.WClientLayoutEnd:
                    // a3edb710-21fc-4f91-97f4-ac2b0df1c20f
                    return new Guid(0xA3EDB710, 0x21FC, 0x4F91, 0x97, 0xF4, 0xAC, 0x2B, 0xD, 0xF1, 0xC2, 0xF);
                case Event.WClientMeasureBegin:
                case Event.WClientMeasureAbort:
                case Event.WClientMeasureEnd:
                case Event.WClientMeasureElementBegin:
                case Event.WClientMeasureElementEnd:
                    // 3005e67b-129c-4ced-bcaa-91d7d73b1544
                    return new Guid(0x3005E67B, 0x129C, 0x4CED, 0xBC, 0xAA, 0x91, 0xD7, 0xD7, 0x3B, 0x15, 0x44);
                case Event.WClientArrangeBegin:
                case Event.WClientArrangeAbort:
                case Event.WClientArrangeEnd:
                case Event.WClientArrangeElementBegin:
                case Event.WClientArrangeElementEnd:
                    // 4b0ef3d1-0cbb-4847-b98f-16408e7e83f3
                    return new Guid(0x4B0EF3D1, 0xCBB, 0x4847, 0xB9, 0x8F, 0x16, 0x40, 0x8E, 0x7E, 0x83, 0xF3);
                case Event.WClientLayoutAbort:
                case Event.WClientLayoutFireSizeChangedBegin:
                case Event.WClientLayoutFireSizeChangedEnd:
                case Event.WClientLayoutFireLayoutUpdatedBegin:
                case Event.WClientLayoutFireLayoutUpdatedEnd:
                case Event.WClientLayoutFireAutomationEventsBegin:
                case Event.WClientLayoutFireAutomationEventsEnd:
                case Event.WClientLayoutException:
                case Event.WClientLayoutInvalidated:
                    // a3edb710-21fc-4f91-97f4-ac2b0df1c20f
                    return new Guid(0xA3EDB710, 0x21FC, 0x4F91, 0x97, 0xF4, 0xAC, 0x2B, 0xD, 0xF1, 0xC2, 0xF);
                case Event.WpfHostUm_WinMainStart:
                case Event.WpfHostUm_WinMainEnd:
                case Event.WpfHostUm_InvokingBrowser:
                case Event.WpfHostUm_LaunchingRestrictedProcess:
                case Event.WpfHostUm_EnteringMessageLoop:
                case Event.WpfHostUm_ClassFactoryCreateInstance:
                case Event.WpfHostUm_ReadingDeplManifestStart:
                case Event.WpfHostUm_ReadingDeplManifestEnd:
                case Event.WpfHostUm_ReadingAppManifestStart:
                case Event.WpfHostUm_ReadingAppManifestEnd:
                case Event.WpfHostUm_ParsingMarkupVersionStart:
                case Event.WpfHostUm_ParsingMarkupVersionEnd:
                case Event.WpfHostUm_IPersistFileLoad:
                case Event.WpfHostUm_IPersistMonikerLoadStart:
                case Event.WpfHostUm_IPersistMonikerLoadEnd:
                case Event.WpfHostUm_BindProgress:
                case Event.WpfHostUm_OnStopBinding:
                case Event.WpfHostUm_VersionAttach:
                case Event.WpfHostUm_VersionActivateStart:
                case Event.WpfHostUm_VersionActivateEnd:
                case Event.WpfHostUm_StartingCLRStart:
                case Event.WpfHostUm_StartingCLREnd:
                case Event.WpfHostUm_IHlinkTargetNavigateStart:
                case Event.WpfHostUm_IHlinkTargetNavigateEnd:
                case Event.WpfHostUm_ReadyStateChanged:
                case Event.WpfHostUm_InitDocHostStart:
                case Event.WpfHostUm_InitDocHostEnd:
                case Event.WpfHostUm_MergingMenusStart:
                case Event.WpfHostUm_MergingMenusEnd:
                case Event.WpfHostUm_UIActivationStart:
                case Event.WpfHostUm_UIActivationEnd:
                case Event.WpfHostUm_LoadingResourceDLLStart:
                case Event.WpfHostUm_LoadingResourceDLLEnd:
                case Event.WpfHostUm_OleCmdQueryStatusStart:
                case Event.WpfHostUm_OleCmdQueryStatusEnd:
                case Event.WpfHostUm_OleCmdExecStart:
                case Event.WpfHostUm_OleCmdExecEnd:
                case Event.WpfHostUm_ProgressPageShown:
                case Event.WpfHostUm_AdHocProfile1Start:
                case Event.WpfHostUm_AdHocProfile1End:
                case Event.WpfHostUm_AdHocProfile2Start:
                case Event.WpfHostUm_AdHocProfile2End:
                    // ed251760-7bbc-4b25-8328-cd7f271fee89
                    return new Guid(0xED251760, 0x7BBC, 0x4B25, 0x83, 0x28, 0xCD, 0x7F, 0x27, 0x1F, 0xEE, 0x89);
                case Event.WpfHost_DocObjHostCreated:
                case Event.WpfHost_XappLauncherAppStartup:
                case Event.WpfHost_XappLauncherAppExit:
                case Event.WpfHost_DocObjHostRunApplicationStart:
                case Event.WpfHost_DocObjHostRunApplicationEnd:
                case Event.WpfHost_ClickOnceActivationStart:
                case Event.WpfHost_ClickOnceActivationEnd:
                case Event.WpfHost_InitAppProxyStart:
                case Event.WpfHost_InitAppProxyEnd:
                case Event.WpfHost_AppProxyCtor:
                case Event.WpfHost_RootBrowserWindowSetupStart:
                case Event.WpfHost_RootBrowserWindowSetupEnd:
                case Event.WpfHost_AppProxyRunStart:
                case Event.WpfHost_AppProxyRunEnd:
                case Event.WpfHost_AppDomainManagerCctor:
                case Event.WpfHost_ApplicationActivatorCreateInstanceStart:
                case Event.WpfHost_ApplicationActivatorCreateInstanceEnd:
                case Event.WpfHost_DetermineApplicationTrustStart:
                case Event.WpfHost_DetermineApplicationTrustEnd:
                case Event.WpfHost_FirstTimeActivation:
                case Event.WpfHost_GetDownloadPageStart:
                case Event.WpfHost_GetDownloadPageEnd:
                case Event.WpfHost_DownloadDeplManifestStart:
                case Event.WpfHost_DownloadDeplManifestEnd:
                case Event.WpfHost_AssertAppRequirementsStart:
                case Event.WpfHost_AssertAppRequirementsEnd:
                case Event.WpfHost_DownloadApplicationStart:
                case Event.WpfHost_DownloadApplicationEnd:
                case Event.WpfHost_DownloadProgressUpdate:
                case Event.WpfHost_XappLauncherAppNavigated:
                case Event.WpfHost_UpdateBrowserCommandsStart:
                case Event.WpfHost_UpdateBrowserCommandsEnd:
                case Event.WpfHost_PostShutdown:
                case Event.WpfHost_AbortingActivation:
                case Event.WpfHost_IBHSRunStart:
                case Event.WpfHost_IBHSRunEnd:
                    // 5ff6b585-7fb9-4189-beb3-54c82ce4d7d1
                    return new Guid(0x5FF6B585, 0x7FB9, 0x4189, 0xBE, 0xB3, 0x54, 0xC8, 0x2C, 0xE4, 0xD7, 0xD1);
                case Event.Wpf_NavigationAsyncWorkItem:
                case Event.Wpf_NavigationWebResponseReceived:
                case Event.Wpf_NavigationEnd:
                case Event.Wpf_NavigationContentRendered:
                case Event.Wpf_NavigationStart:
                case Event.Wpf_NavigationLaunchBrowser:
                case Event.Wpf_NavigationPageFunctionReturn:
                    // 6ffb9c25-5c8a-4091-989c-5b596ab286a0
                    return new Guid(0x6FFB9C25, 0x5C8A, 0x4091, 0x98, 0x9C, 0x5B, 0x59, 0x6A, 0xB2, 0x86, 0xA0);
                case Event.DrawBitmapInfo:
                    // a7f1ef9d-9bb9-4c7d-93ad-11919b122fa2
                    return new Guid(0xA7F1EF9D, 0x9BB9, 0x4C7D, 0x93, 0xAD, 0x11, 0x91, 0x9B, 0x12, 0x2F, 0xA2);
                case Event.BitmapCopyInfo:
                    // 5c02c62f-aec1-4f0c-b4a7-511d280184fd
                    return new Guid(0x5C02C62F, 0xAEC1, 0x4F0C, 0xB4, 0xA7, 0x51, 0x1D, 0x28, 0x1, 0x84, 0xFD);
                case Event.SetClipInfo:
                    // 6acaf5f0-d340-4373-a851-fea1267aa210
                    return new Guid(0x6ACAF5F0, 0xD340, 0x4373, 0xA8, 0x51, 0xFE, 0xA1, 0x26, 0x7A, 0xA2, 0x10);
                case Event.DWMDraw_ClearStart:
                case Event.DWMDraw_ClearEnd:
                    // c8960930-bf29-4c06-8574-d4be803f13f9
                    return new Guid(0xC8960930, 0xBF29, 0x4C06, 0x85, 0x74, 0xD4, 0xBE, 0x80, 0x3F, 0x13, 0xF9);
                case Event.DWMDraw_BitmapStart:
                case Event.DWMDraw_BitmapEnd:
                case Event.DWMDraw_RectangleStart:
                case Event.DWMDraw_RectangleEnd:
                case Event.DWMDraw_GeometryStart:
                case Event.DWMDraw_GeometryEnd:
                case Event.DWMDraw_ImageStart:
                case Event.DWMDraw_ImageEnd:
                case Event.DWMDraw_GlyphRunStart:
                case Event.DWMDraw_GlyphRunEnd:
                case Event.DWMDraw_BeginLayerStart:
                case Event.DWMDraw_BeginLayerEnd:
                case Event.DWMDraw_EndLayerStart:
                case Event.DWMDraw_EndLayerEnd:
                case Event.DWMDraw_ClippedBitmapStart:
                case Event.DWMDraw_ClippedBitmapEnd:
                case Event.DWMDraw_Info:
                    // c4e8f367-3ba1-4c75-b985-facbb4274dd7
                    return new Guid(0xC4E8F367, 0x3BA1, 0x4C75, 0xB9, 0x85, 0xFA, 0xCB, 0xB4, 0x27, 0x4D, 0xD7);
                case Event.LayerEventStart:
                case Event.LayerEventEnd:
                    // ead9a51b-d3d3-4b0b-8d25-e4914ed4c1ed
                    return new Guid(0xEAD9A51B, 0xD3D3, 0x4B0B, 0x8D, 0x25, 0xE4, 0x91, 0x4E, 0xD4, 0xC1, 0xED);
                case Event.WClientDesktopRTCreateBegin:
                case Event.WClientDesktopRTCreateEnd:
                    // 2e62c3bf-7c51-43fb-8cdc-915d4abc09dd
                    return new Guid(0x2E62C3BF, 0x7C51, 0x43FB, 0x8C, 0xDC, 0x91, 0x5D, 0x4A, 0xBC, 0x9, 0xDD);
                case Event.WClientUceProcessQueueBegin:
                case Event.WClientUceProcessQueueEnd:
                case Event.WClientUceProcessQueueInfo:
                    // b7c7f692-f2b4-447a-b5df-fa6c314889ae
                    return new Guid(0xB7C7F692, 0xF2B4, 0x447A, 0xB5, 0xDF, 0xFA, 0x6C, 0x31, 0x48, 0x89, 0xAE);
                case Event.WClientUcePrecomputeBegin:
                case Event.WClientUcePrecomputeEnd:
                    // de51ae60-46ad-4cc0-9a29-426a87e88e9f
                    return new Guid(0xDE51AE60, 0x46AD, 0x4CC0, 0x9A, 0x29, 0x42, 0x6A, 0x87, 0xE8, 0x8E, 0x9F);
                case Event.WClientUceRenderBegin:
                case Event.WClientUceRenderEnd:
                    // 92ca500c-67b1-447f-9497-cfd6d52a5b0e
                    return new Guid(0x92CA500C, 0x67B1, 0x447F, 0x94, 0x97, 0xCF, 0xD6, 0xD5, 0x2A, 0x5B, 0xE);
                case Event.WClientUcePresentBegin:
                case Event.WClientUcePresentEnd:
                    // 4c48d6ef-ac14-4d84-ba37-49a94ba8d2af
                    return new Guid(0x4C48D6EF, 0xAC14, 0x4D84, 0xBA, 0x37, 0x49, 0xA9, 0x4B, 0xA8, 0xD2, 0xAF);
                case Event.WClientUceResponse:
                    // 4c253b24-7230-4fa1-9748-ac4c59cf288c
                    return new Guid(0x4C253B24, 0x7230, 0x4FA1, 0x97, 0x48, 0xAC, 0x4C, 0x59, 0xCF, 0x28, 0x8C);
                case Event.WClientUceCheckDeviceStateInfo:
                    // 76601d6d-c6d4-4e8d-ac6e-3f9b4f1745e0
                    return new Guid(0x76601D6D, 0xC6D4, 0x4E8D, 0xAC, 0x6E, 0x3F, 0x9B, 0x4F, 0x17, 0x45, 0xE0);
                case Event.VisualCacheAlloc:
                    // 85eb64f6-dc84-43c6-b14c-3bd607f42c0d
                    return new Guid(0x85EB64F6, 0xDC84, 0x43C6, 0xB1, 0x4C, 0x3B, 0xD6, 0x7, 0xF4, 0x2C, 0xD);
                case Event.VisualCacheUpdate:
                    // a4fdb257-f156-48f6-b0f5-c4a944b553fb
                    return new Guid(0xA4FDB257, 0xF156, 0x48F6, 0xB0, 0xF5, 0xC4, 0xA9, 0x44, 0xB5, 0x53, 0xFB);
                case Event.CreateChannel:
                    // 1c415c02-1446-480c-a81e-b2967ee7e20a
                    return new Guid(0x1C415C02, 0x1446, 0x480C, 0xA8, 0x1E, 0xB2, 0x96, 0x7E, 0xE7, 0xE2, 0xA);
                case Event.CreateOrAddResourceOnChannel:
                    // a9ee6bda-f0df-4e2d-a3dd-25ca8fb39f1f
                    return new Guid(0xA9EE6BDA, 0xF0DF, 0x4E2D, 0xA3, 0xDD, 0x25, 0xCA, 0x8F, 0xB3, 0x9F, 0x1F);
                case Event.CreateWpfGfxResource:
                    // 9de2b56b-79a4-497c-88f2-d5bedc042a9d
                    return new Guid(0x9DE2B56B, 0x79A4, 0x497C, 0x88, 0xF2, 0xD5, 0xBE, 0xDC, 0x4, 0x2A, 0x9D);
                case Event.ReleaseOnChannel:
                    // 8a61870b-a794-477e-9093-282e09eabe59
                    return new Guid(0x8A61870B, 0xA794, 0x477E, 0x90, 0x93, 0x28, 0x2E, 0x9, 0xEA, 0xBE, 0x59);
                case Event.UnexpectedSoftwareFallback:
                    // 7d2c8338-c13c-4c5c-867a-c56c980354e4
                    return new Guid(0x7D2C8338, 0xC13C, 0x4C5C, 0x86, 0x7A, 0xC5, 0x6C, 0x98, 0x3, 0x54, 0xE4);
                case Event.WClientInterlockedRenderBegin:
                case Event.WClientInterlockedRenderEnd:
                    // 7fe9630d-93dd-45b1-9459-21c7a4113174
                    return new Guid(0x7FE9630D, 0x93DD, 0x45B1, 0x94, 0x59, 0x21, 0xC7, 0xA4, 0x11, 0x31, 0x74);
                case Event.WClientRenderHandlerBegin:
                case Event.WClientRenderHandlerEnd:
                    // 7723d8b7-488b-4f80-b089-46a4c6aca1c4
                    return new Guid(0x7723D8B7, 0x488B, 0x4F80, 0xB0, 0x89, 0x46, 0xA4, 0xC6, 0xAC, 0xA1, 0xC4);
                case Event.WClientAnimRenderHandlerBegin:
                case Event.WClientAnimRenderHandlerEnd:
                    // 521c1c8d-faaa-435b-ad8c-1d64442bfd70
                    return new Guid(0x521C1C8D, 0xFAAA, 0x435B, 0xAD, 0x8C, 0x1D, 0x64, 0x44, 0x2B, 0xFD, 0x70);
                case Event.WClientMediaRenderBegin:
                case Event.WClientMediaRenderEnd:
                    // 6827e447-0e0e-4b5e-ae81-b79a00ec8349
                    return new Guid(0x6827E447, 0xE0E, 0x4B5E, 0xAE, 0x81, 0xB7, 0x9A, 0x0, 0xEC, 0x83, 0x49);
                case Event.WClientPostRender:
                    // fb69cd45-c00d-4c23-9765-69c00344b2c5
                    return new Guid(0xFB69CD45, 0xC00D, 0x4C23, 0x97, 0x65, 0x69, 0xC0, 0x3, 0x44, 0xB2, 0xC5);
                case Event.WClientQPCFrequency:
                    // 30ee0097-084c-408b-9038-73bed0479873
                    return new Guid(0x30EE0097, 0x84C, 0x408B, 0x90, 0x38, 0x73, 0xBE, 0xD0, 0x47, 0x98, 0x73);
                case Event.WClientPrecomputeSceneBegin:
                case Event.WClientPrecomputeSceneEnd:
                    // 3331420f-7a3b-42b6-8dfe-aabf472801da
                    return new Guid(0x3331420F, 0x7A3B, 0x42B6, 0x8D, 0xFE, 0xAA, 0xBF, 0x47, 0x28, 0x1, 0xDA);
                case Event.WClientCompileSceneBegin:
                case Event.WClientCompileSceneEnd:
                    // af36fcb5-58e5-48d0-88d0-d8f4dcb56a12
                    return new Guid(0xAF36FCB5, 0x58E5, 0x48D0, 0x88, 0xD0, 0xD8, 0xF4, 0xDC, 0xB5, 0x6A, 0x12);
                case Event.WClientUIResponse:
                    // ab29585b-4794-4465-91e6-9df5861c88c5
                    return new Guid(0xAB29585B, 0x4794, 0x4465, 0x91, 0xE6, 0x9D, 0xF5, 0x86, 0x1C, 0x88, 0xC5);
                case Event.WClientUICommitChannel:
                    // f9c0372e-60bd-46c9-bc64-94fe5fd31fe4
                    return new Guid(0xF9C0372E, 0x60BD, 0x46C9, 0xBC, 0x64, 0x94, 0xFE, 0x5F, 0xD3, 0x1F, 0xE4);
                case Event.WClientUceNotifyPresent:
                    // 24cd1476-e145-4e5a-8bfc-50c36bbdf9cc
                    return new Guid(0x24CD1476, 0xE145, 0x4E5A, 0x8B, 0xFC, 0x50, 0xC3, 0x6B, 0xBD, 0xF9, 0xCC);
                case Event.WClientScheduleRender:
                    // 6d5aeaf3-a433-4daa-8b31-d8ae49cf6bd1
                    return new Guid(0x6D5AEAF3, 0xA433, 0x4DAA, 0x8B, 0x31, 0xD8, 0xAE, 0x49, 0xCF, 0x6B, 0xD1);
                case Event.WClientOnRenderBegin:
                case Event.WClientOnRenderEnd:
                    // 3a475cef-0e2a-449b-986e-efff5d6260e7
                    return new Guid(0x3A475CEF, 0xE2A, 0x449B, 0x98, 0x6E, 0xEF, 0xFF, 0x5D, 0x62, 0x60, 0xE7);
                case Event.WClientCreateIRT:
                    // d56e7b1e-e24c-4b0b-9c4a-8881f7005633
                    return new Guid(0xD56E7B1E, 0xE24C, 0x4B0B, 0x9C, 0x4A, 0x88, 0x81, 0xF7, 0x0, 0x56, 0x33);
                case Event.WClientPotentialIRTResource:
                    // 4055bbd6-ba41-4bd0-bc0d-6b67965229be
                    return new Guid(0x4055BBD6, 0xBA41, 0x4BD0, 0xBC, 0xD, 0x6B, 0x67, 0x96, 0x52, 0x29, 0xBE);
                case Event.WClientUIContextDispatchBegin:
                case Event.WClientUIContextDispatchEnd:
                    // 2481a374-999f-4ad2-9f22-6b7c8e2a5db0
                    return new Guid(0x2481A374, 0x999F, 0x4AD2, 0x9F, 0x22, 0x6B, 0x7C, 0x8E, 0x2A, 0x5D, 0xB0);
                case Event.WClientUIContextPost:
                    // 76287aef-f674-4061-a60a-76f95550efeb
                    return new Guid(0x76287AEF, 0xF674, 0x4061, 0xA6, 0xA, 0x76, 0xF9, 0x55, 0x50, 0xEF, 0xEB);
                case Event.WClientUIContextAbort:
                    // 39404da9-413f-4581-a0a1-4715168b5ad8
                    return new Guid(0x39404DA9, 0x413F, 0x4581, 0xA0, 0xA1, 0x47, 0x15, 0x16, 0x8B, 0x5A, 0xD8);
                case Event.WClientUIContextPromote:
                    // 632d4e9e-b988-4b32-ab2a-b37aa34927ee
                    return new Guid(0x632D4E9E, 0xB988, 0x4B32, 0xAB, 0x2A, 0xB3, 0x7A, 0xA3, 0x49, 0x27, 0xEE);
                case Event.WClientUIContextIdle:
                    // c626ebef-0780-487f-81d7-38d3f0a6f05e
                    return new Guid(0xC626EBEF, 0x780, 0x487F, 0x81, 0xD7, 0x38, 0xD3, 0xF0, 0xA6, 0xF0, 0x5E);
                default: throw new ArgumentException(Strings.InvalidEvent, nameof(arg));
            }
        }

        internal static ushort GetTaskForEvent(Event arg)
        {
            switch (arg)
            {
                case Event.WClientCreateVisual:
                    return 28;
                case Event.WClientAppCtor:
                    return 48;
                case Event.WClientAppRun:
                    return 49;
                case Event.WClientString:
                case Event.WClientStringBegin:
                case Event.WClientStringEnd:
                    return 51;
                case Event.WClientPropParentCheck:
                    return 85;
                case Event.UpdateVisualStateStart:
                case Event.UpdateVisualStateEnd:
                    return 129;
                case Event.PerfElementIDName:
                case Event.PerfElementIDAssignment:
                    return 143;
                case Event.WClientFontCache:
                    return 52;
                case Event.WClientInputMessage:
                    return 29;
                case Event.StylusEventQueued:
                    return 132;
                case Event.TouchDownReported:
                    return 133;
                case Event.TouchMoveReported:
                    return 134;
                case Event.TouchUpReported:
                    return 135;
                case Event.ManipulationReportFrame:
                    return 136;
                case Event.ManipulationEventRaised:
                    return 137;
                case Event.PenThreadPoolThreadAcquisition:
                    return 147;
                case Event.CreateStickyNoteBegin:
                case Event.CreateStickyNoteEnd:
                    return 92;
                case Event.DeleteTextNoteBegin:
                case Event.DeleteTextNoteEnd:
                    return 93;
                case Event.DeleteInkNoteBegin:
                case Event.DeleteInkNoteEnd:
                    return 94;
                case Event.CreateHighlightBegin:
                case Event.CreateHighlightEnd:
                    return 95;
                case Event.ClearHighlightBegin:
                case Event.ClearHighlightEnd:
                    return 96;
                case Event.LoadAnnotationsBegin:
                case Event.LoadAnnotationsEnd:
                    return 97;
                case Event.AddAnnotationBegin:
                case Event.AddAnnotationEnd:
                    return 99;
                case Event.DeleteAnnotationBegin:
                case Event.DeleteAnnotationEnd:
                    return 100;
                case Event.GetAnnotationByIdBegin:
                case Event.GetAnnotationByIdEnd:
                    return 101;
                case Event.GetAnnotationByLocBegin:
                case Event.GetAnnotationByLocEnd:
                    return 102;
                case Event.GetAnnotationsBegin:
                case Event.GetAnnotationsEnd:
                    return 103;
                case Event.SerializeAnnotationBegin:
                case Event.SerializeAnnotationEnd:
                    return 104;
                case Event.DeserializeAnnotationBegin:
                case Event.DeserializeAnnotationEnd:
                    return 105;
                case Event.UpdateAnnotationWithSNCBegin:
                case Event.UpdateAnnotationWithSNCEnd:
                    return 106;
                case Event.UpdateSNCWithAnnotationBegin:
                case Event.UpdateSNCWithAnnotationEnd:
                    return 107;
                case Event.AnnotationTextChangedBegin:
                case Event.AnnotationTextChangedEnd:
                    return 108;
                case Event.AnnotationInkChangedBegin:
                case Event.AnnotationInkChangedEnd:
                    return 109;
                case Event.AddAttachedSNBegin:
                case Event.AddAttachedSNEnd:
                    return 110;
                case Event.RemoveAttachedSNBegin:
                case Event.RemoveAttachedSNEnd:
                    return 111;
                case Event.AddAttachedHighlightBegin:
                case Event.AddAttachedHighlightEnd:
                    return 112;
                case Event.RemoveAttachedHighlightBegin:
                case Event.RemoveAttachedHighlightEnd:
                    return 113;
                case Event.AddAttachedMHBegin:
                case Event.AddAttachedMHEnd:
                    return 114;
                case Event.RemoveAttachedMHBegin:
                case Event.RemoveAttachedMHEnd:
                    return 115;
                case Event.WClientParseBamlBegin:
                case Event.WClientParseBamlEnd:
                    return 41;
                case Event.WClientParseXmlBegin:
                case Event.WClientParseXmlEnd:
                    return 43;
                case Event.WClientParseFefCrInstBegin:
                case Event.WClientParseFefCrInstEnd:
                    return 44;
                case Event.WClientParseInstVisTreeBegin:
                case Event.WClientParseInstVisTreeEnd:
                    return 45;
                case Event.WClientParseRdrCrInstBegin:
                case Event.WClientParseRdrCrInstEnd:
                    return 46;
                case Event.WClientParseRdrCrInFTypBegin:
                case Event.WClientParseRdrCrInFTypEnd:
                    return 47;
                case Event.WClientResourceFindBegin:
                case Event.WClientResourceFindEnd:
                    return 86;
                case Event.WClientResourceCacheValue:
                    return 87;
                case Event.WClientResourceCacheNull:
                    return 88;
                case Event.WClientResourceCacheMiss:
                    return 89;
                case Event.WClientResourceStock:
                    return 90;
                case Event.WClientResourceBamlAssembly:
                    return 91;
                case Event.WClientParseXamlBegin:
                    return 42;
                case Event.WClientParseXamlBamlInfo:
                    return 144;
                case Event.WClientParseXamlEnd:
                    return 42;
                case Event.WClientDRXFlushPageStart:
                case Event.WClientDRXFlushPageStop:
                    return 121;
                case Event.WClientDRXSerializeTreeStart:
                case Event.WClientDRXSerializeTreeEnd:
                    return 123;
                case Event.WClientDRXGetVisualStart:
                case Event.WClientDRXGetVisualEnd:
                    return 122;
                case Event.WClientDRXReleaseWriterStart:
                case Event.WClientDRXReleaseWriterEnd:
                    return 124;
                case Event.WClientDRXGetPrintCapStart:
                case Event.WClientDRXGetPrintCapEnd:
                    return 125;
                case Event.WClientDRXPTProviderStart:
                case Event.WClientDRXPTProviderEnd:
                    return 126;
                case Event.WClientDRXRasterStart:
                case Event.WClientDRXRasterEnd:
                    return 127;
                case Event.WClientDRXOpenPackageBegin:
                case Event.WClientDRXOpenPackageEnd:
                    return 53;
                case Event.WClientDRXGetStreamBegin:
                case Event.WClientDRXGetStreamEnd:
                    return 55;
                case Event.WClientDRXPageVisible:
                    return 56;
                case Event.WClientDRXPageLoaded:
                    return 57;
                case Event.WClientDRXInvalidateView:
                    return 58;
                case Event.WClientDRXStyleCreated:
                    return 64;
                case Event.WClientDRXFindBegin:
                case Event.WClientDRXFindEnd:
                    return 65;
                case Event.WClientDRXZoom:
                    return 66;
                case Event.WClientDRXEnsureOMBegin:
                case Event.WClientDRXEnsureOMEnd:
                    return 67;
                case Event.WClientDRXTreeFlattenBegin:
                case Event.WClientDRXTreeFlattenEnd:
                    return 69;
                case Event.WClientDRXAlphaFlattenBegin:
                case Event.WClientDRXAlphaFlattenEnd:
                    return 70;
                case Event.WClientDRXGetDevModeBegin:
                case Event.WClientDRXGetDevModeEnd:
                    return 71;
                case Event.WClientDRXStartDocBegin:
                case Event.WClientDRXStartDocEnd:
                    return 72;
                case Event.WClientDRXEndDocBegin:
                case Event.WClientDRXEndDocEnd:
                    return 73;
                case Event.WClientDRXStartPageBegin:
                case Event.WClientDRXStartPageEnd:
                    return 74;
                case Event.WClientDRXEndPageBegin:
                case Event.WClientDRXEndPageEnd:
                    return 75;
                case Event.WClientDRXCommitPageBegin:
                case Event.WClientDRXCommitPageEnd:
                    return 76;
                case Event.WClientDRXConvertFontBegin:
                case Event.WClientDRXConvertFontEnd:
                    return 77;
                case Event.WClientDRXConvertImageBegin:
                case Event.WClientDRXConvertImageEnd:
                    return 78;
                case Event.WClientDRXSaveXpsBegin:
                case Event.WClientDRXSaveXpsEnd:
                    return 79;
                case Event.WClientDRXLoadPrimitiveBegin:
                case Event.WClientDRXLoadPrimitiveEnd:
                    return 80;
                case Event.WClientDRXSavePageBegin:
                case Event.WClientDRXSavePageEnd:
                    return 81;
                case Event.WClientDRXSerializationBegin:
                case Event.WClientDRXSerializationEnd:
                    return 82;
                case Event.WClientDRXReadStreamBegin:
                case Event.WClientDRXReadStreamEnd:
                    return 54;
                case Event.WClientDRXGetPageBegin:
                case Event.WClientDRXGetPageEnd:
                    return 68;
                case Event.WClientDRXLineDown:
                    return 59;
                case Event.WClientDRXPageDown:
                    return 60;
                case Event.WClientDRXPageJump:
                    return 61;
                case Event.WClientDRXLayoutBegin:
                case Event.WClientDRXLayoutEnd:
                    return 62;
                case Event.WClientDRXInstantiated:
                    return 63;
                case Event.WClientTimeManagerTickBegin:
                case Event.WClientTimeManagerTickEnd:
                    return 50;
                case Event.WClientLayoutBegin:
                case Event.WClientLayoutEnd:
                    return 25;
                case Event.WClientMeasureBegin:
                case Event.WClientMeasureAbort:
                case Event.WClientMeasureEnd:
                case Event.WClientMeasureElementBegin:
                case Event.WClientMeasureElementEnd:
                    return 26;
                case Event.WClientArrangeBegin:
                case Event.WClientArrangeAbort:
                case Event.WClientArrangeEnd:
                case Event.WClientArrangeElementBegin:
                case Event.WClientArrangeElementEnd:
                    return 27;
                case Event.WClientLayoutAbort:
                case Event.WClientLayoutFireSizeChangedBegin:
                case Event.WClientLayoutFireSizeChangedEnd:
                case Event.WClientLayoutFireLayoutUpdatedBegin:
                case Event.WClientLayoutFireLayoutUpdatedEnd:
                case Event.WClientLayoutFireAutomationEventsBegin:
                case Event.WClientLayoutFireAutomationEventsEnd:
                case Event.WClientLayoutException:
                case Event.WClientLayoutInvalidated:
                    return 25;
                case Event.WpfHostUm_WinMainStart:
                case Event.WpfHostUm_WinMainEnd:
                case Event.WpfHostUm_InvokingBrowser:
                case Event.WpfHostUm_LaunchingRestrictedProcess:
                case Event.WpfHostUm_EnteringMessageLoop:
                case Event.WpfHostUm_ClassFactoryCreateInstance:
                case Event.WpfHostUm_ReadingDeplManifestStart:
                case Event.WpfHostUm_ReadingDeplManifestEnd:
                case Event.WpfHostUm_ReadingAppManifestStart:
                case Event.WpfHostUm_ReadingAppManifestEnd:
                case Event.WpfHostUm_ParsingMarkupVersionStart:
                case Event.WpfHostUm_ParsingMarkupVersionEnd:
                case Event.WpfHostUm_IPersistFileLoad:
                case Event.WpfHostUm_IPersistMonikerLoadStart:
                case Event.WpfHostUm_IPersistMonikerLoadEnd:
                case Event.WpfHostUm_BindProgress:
                case Event.WpfHostUm_OnStopBinding:
                case Event.WpfHostUm_VersionAttach:
                case Event.WpfHostUm_VersionActivateStart:
                case Event.WpfHostUm_VersionActivateEnd:
                case Event.WpfHostUm_StartingCLRStart:
                case Event.WpfHostUm_StartingCLREnd:
                case Event.WpfHostUm_IHlinkTargetNavigateStart:
                case Event.WpfHostUm_IHlinkTargetNavigateEnd:
                case Event.WpfHostUm_ReadyStateChanged:
                case Event.WpfHostUm_InitDocHostStart:
                case Event.WpfHostUm_InitDocHostEnd:
                case Event.WpfHostUm_MergingMenusStart:
                case Event.WpfHostUm_MergingMenusEnd:
                case Event.WpfHostUm_UIActivationStart:
                case Event.WpfHostUm_UIActivationEnd:
                case Event.WpfHostUm_LoadingResourceDLLStart:
                case Event.WpfHostUm_LoadingResourceDLLEnd:
                case Event.WpfHostUm_OleCmdQueryStatusStart:
                case Event.WpfHostUm_OleCmdQueryStatusEnd:
                case Event.WpfHostUm_OleCmdExecStart:
                case Event.WpfHostUm_OleCmdExecEnd:
                case Event.WpfHostUm_ProgressPageShown:
                case Event.WpfHostUm_AdHocProfile1Start:
                case Event.WpfHostUm_AdHocProfile1End:
                case Event.WpfHostUm_AdHocProfile2Start:
                case Event.WpfHostUm_AdHocProfile2End:
                    return 116;
                case Event.WpfHost_DocObjHostCreated:
                case Event.WpfHost_XappLauncherAppStartup:
                case Event.WpfHost_XappLauncherAppExit:
                case Event.WpfHost_DocObjHostRunApplicationStart:
                case Event.WpfHost_DocObjHostRunApplicationEnd:
                case Event.WpfHost_ClickOnceActivationStart:
                case Event.WpfHost_ClickOnceActivationEnd:
                case Event.WpfHost_InitAppProxyStart:
                case Event.WpfHost_InitAppProxyEnd:
                case Event.WpfHost_AppProxyCtor:
                case Event.WpfHost_RootBrowserWindowSetupStart:
                case Event.WpfHost_RootBrowserWindowSetupEnd:
                case Event.WpfHost_AppProxyRunStart:
                case Event.WpfHost_AppProxyRunEnd:
                case Event.WpfHost_AppDomainManagerCctor:
                case Event.WpfHost_ApplicationActivatorCreateInstanceStart:
                case Event.WpfHost_ApplicationActivatorCreateInstanceEnd:
                case Event.WpfHost_DetermineApplicationTrustStart:
                case Event.WpfHost_DetermineApplicationTrustEnd:
                case Event.WpfHost_FirstTimeActivation:
                case Event.WpfHost_GetDownloadPageStart:
                case Event.WpfHost_GetDownloadPageEnd:
                case Event.WpfHost_DownloadDeplManifestStart:
                case Event.WpfHost_DownloadDeplManifestEnd:
                case Event.WpfHost_AssertAppRequirementsStart:
                case Event.WpfHost_AssertAppRequirementsEnd:
                case Event.WpfHost_DownloadApplicationStart:
                case Event.WpfHost_DownloadApplicationEnd:
                case Event.WpfHost_DownloadProgressUpdate:
                case Event.WpfHost_XappLauncherAppNavigated:
                case Event.WpfHost_UpdateBrowserCommandsStart:
                case Event.WpfHost_UpdateBrowserCommandsEnd:
                case Event.WpfHost_PostShutdown:
                case Event.WpfHost_AbortingActivation:
                case Event.WpfHost_IBHSRunStart:
                case Event.WpfHost_IBHSRunEnd:
                    return 117;
                case Event.Wpf_NavigationAsyncWorkItem:
                case Event.Wpf_NavigationWebResponseReceived:
                case Event.Wpf_NavigationEnd:
                case Event.Wpf_NavigationContentRendered:
                case Event.Wpf_NavigationStart:
                case Event.Wpf_NavigationLaunchBrowser:
                case Event.Wpf_NavigationPageFunctionReturn:
                    return 118;
                case Event.DrawBitmapInfo:
                    return 1;
                case Event.BitmapCopyInfo:
                    return 2;
                case Event.SetClipInfo:
                    return 3;
                case Event.DWMDraw_ClearStart:
                case Event.DWMDraw_ClearEnd:
                    return 5;
                case Event.DWMDraw_BitmapStart:
                case Event.DWMDraw_BitmapEnd:
                case Event.DWMDraw_RectangleStart:
                case Event.DWMDraw_RectangleEnd:
                case Event.DWMDraw_GeometryStart:
                case Event.DWMDraw_GeometryEnd:
                case Event.DWMDraw_ImageStart:
                case Event.DWMDraw_ImageEnd:
                case Event.DWMDraw_GlyphRunStart:
                case Event.DWMDraw_GlyphRunEnd:
                case Event.DWMDraw_BeginLayerStart:
                case Event.DWMDraw_BeginLayerEnd:
                case Event.DWMDraw_EndLayerStart:
                case Event.DWMDraw_EndLayerEnd:
                case Event.DWMDraw_ClippedBitmapStart:
                case Event.DWMDraw_ClippedBitmapEnd:
                case Event.DWMDraw_Info:
                    return 8;
                case Event.LayerEventStart:
                case Event.LayerEventEnd:
                    return 9;
                case Event.WClientDesktopRTCreateBegin:
                case Event.WClientDesktopRTCreateEnd:
                    return 12;
                case Event.WClientUceProcessQueueBegin:
                case Event.WClientUceProcessQueueEnd:
                case Event.WClientUceProcessQueueInfo:
                    return 13;
                case Event.WClientUcePrecomputeBegin:
                case Event.WClientUcePrecomputeEnd:
                    return 14;
                case Event.WClientUceRenderBegin:
                case Event.WClientUceRenderEnd:
                    return 15;
                case Event.WClientUcePresentBegin:
                case Event.WClientUcePresentEnd:
                    return 16;
                case Event.WClientUceResponse:
                    return 17;
                case Event.WClientUceCheckDeviceStateInfo:
                    return 19;
                case Event.VisualCacheAlloc:
                    return 130;
                case Event.VisualCacheUpdate:
                    return 131;
                case Event.CreateChannel:
                    return 141;
                case Event.CreateOrAddResourceOnChannel:
                    return 139;
                case Event.CreateWpfGfxResource:
                    return 140;
                case Event.ReleaseOnChannel:
                    return 142;
                case Event.UnexpectedSoftwareFallback:
                    return 128;
                case Event.WClientInterlockedRenderBegin:
                case Event.WClientInterlockedRenderEnd:
                    return 138;
                case Event.WClientRenderHandlerBegin:
                case Event.WClientRenderHandlerEnd:
                    return 30;
                case Event.WClientAnimRenderHandlerBegin:
                case Event.WClientAnimRenderHandlerEnd:
                    return 31;
                case Event.WClientMediaRenderBegin:
                case Event.WClientMediaRenderEnd:
                    return 32;
                case Event.WClientPostRender:
                    return 33;
                case Event.WClientQPCFrequency:
                    return 34;
                case Event.WClientPrecomputeSceneBegin:
                case Event.WClientPrecomputeSceneEnd:
                    return 35;
                case Event.WClientCompileSceneBegin:
                case Event.WClientCompileSceneEnd:
                    return 36;
                case Event.WClientUIResponse:
                    return 37;
                case Event.WClientUICommitChannel:
                    return 38;
                case Event.WClientUceNotifyPresent:
                    return 39;
                case Event.WClientScheduleRender:
                    return 40;
                case Event.WClientOnRenderBegin:
                case Event.WClientOnRenderEnd:
                    return 120;
                case Event.WClientCreateIRT:
                    return 145;
                case Event.WClientPotentialIRTResource:
                    return 146;
                case Event.WClientUIContextDispatchBegin:
                case Event.WClientUIContextDispatchEnd:
                    return 20;
                case Event.WClientUIContextPost:
                    return 21;
                case Event.WClientUIContextAbort:
                    return 22;
                case Event.WClientUIContextPromote:
                    return 23;
                case Event.WClientUIContextIdle:
                    return 24;
                default: throw new ArgumentException(Strings.InvalidEvent, nameof(arg));
            }
        }

        internal static byte GetOpcodeForEvent(Event arg)
        {
            switch (arg)
            {
                case Event.WClientCreateVisual:
                case Event.WClientAppCtor:
                case Event.WClientAppRun:
                case Event.WClientString:
                case Event.WClientPropParentCheck:
                case Event.PerfElementIDAssignment:
                case Event.WClientFontCache:
                case Event.WClientInputMessage:
                case Event.StylusEventQueued:
                case Event.TouchDownReported:
                case Event.TouchMoveReported:
                case Event.TouchUpReported:
                case Event.ManipulationReportFrame:
                case Event.ManipulationEventRaised:
                case Event.PenThreadPoolThreadAcquisition:
                case Event.WClientResourceCacheValue:
                case Event.WClientResourceCacheNull:
                case Event.WClientResourceCacheMiss:
                case Event.WClientResourceStock:
                case Event.WClientResourceBamlAssembly:
                case Event.WClientParseXamlBamlInfo:
                case Event.WClientDRXPageVisible:
                case Event.WClientDRXPageLoaded:
                case Event.WClientDRXInvalidateView:
                case Event.WClientDRXStyleCreated:
                case Event.WClientDRXZoom:
                case Event.WClientDRXLineDown:
                case Event.WClientDRXPageDown:
                case Event.WClientDRXPageJump:
                case Event.WClientDRXInstantiated:
                case Event.DrawBitmapInfo:
                case Event.BitmapCopyInfo:
                case Event.SetClipInfo:
                case Event.DWMDraw_Info:
                case Event.WClientUceProcessQueueInfo:
                case Event.WClientUceResponse:
                case Event.WClientUceCheckDeviceStateInfo:
                case Event.VisualCacheAlloc:
                case Event.VisualCacheUpdate:
                case Event.CreateChannel:
                case Event.CreateOrAddResourceOnChannel:
                case Event.CreateWpfGfxResource:
                case Event.ReleaseOnChannel:
                case Event.UnexpectedSoftwareFallback:
                case Event.WClientPostRender:
                case Event.WClientQPCFrequency:
                case Event.WClientUIResponse:
                case Event.WClientUICommitChannel:
                case Event.WClientUceNotifyPresent:
                case Event.WClientScheduleRender:
                case Event.WClientCreateIRT:
                case Event.WClientPotentialIRTResource:
                case Event.WClientUIContextPost:
                case Event.WClientUIContextAbort:
                case Event.WClientUIContextPromote:
                case Event.WClientUIContextIdle:
                    return 0;
                case Event.WClientStringBegin:
                case Event.UpdateVisualStateStart:
                case Event.CreateStickyNoteBegin:
                case Event.DeleteTextNoteBegin:
                case Event.DeleteInkNoteBegin:
                case Event.CreateHighlightBegin:
                case Event.ClearHighlightBegin:
                case Event.LoadAnnotationsBegin:
                case Event.AddAnnotationBegin:
                case Event.DeleteAnnotationBegin:
                case Event.GetAnnotationByIdBegin:
                case Event.GetAnnotationByLocBegin:
                case Event.GetAnnotationsBegin:
                case Event.SerializeAnnotationBegin:
                case Event.DeserializeAnnotationBegin:
                case Event.UpdateAnnotationWithSNCBegin:
                case Event.UpdateSNCWithAnnotationBegin:
                case Event.AnnotationTextChangedBegin:
                case Event.AnnotationInkChangedBegin:
                case Event.AddAttachedSNBegin:
                case Event.RemoveAttachedSNBegin:
                case Event.AddAttachedHighlightBegin:
                case Event.RemoveAttachedHighlightBegin:
                case Event.AddAttachedMHBegin:
                case Event.RemoveAttachedMHBegin:
                case Event.WClientParseBamlBegin:
                case Event.WClientParseXmlBegin:
                case Event.WClientParseFefCrInstBegin:
                case Event.WClientParseInstVisTreeBegin:
                case Event.WClientParseRdrCrInstBegin:
                case Event.WClientParseRdrCrInFTypBegin:
                case Event.WClientResourceFindBegin:
                case Event.WClientParseXamlBegin:
                case Event.WClientDRXFlushPageStart:
                case Event.WClientDRXSerializeTreeStart:
                case Event.WClientDRXGetVisualStart:
                case Event.WClientDRXReleaseWriterStart:
                case Event.WClientDRXGetPrintCapStart:
                case Event.WClientDRXPTProviderStart:
                case Event.WClientDRXRasterStart:
                case Event.WClientDRXOpenPackageBegin:
                case Event.WClientDRXGetStreamBegin:
                case Event.WClientDRXFindBegin:
                case Event.WClientDRXEnsureOMBegin:
                case Event.WClientDRXTreeFlattenBegin:
                case Event.WClientDRXAlphaFlattenBegin:
                case Event.WClientDRXGetDevModeBegin:
                case Event.WClientDRXStartDocBegin:
                case Event.WClientDRXEndDocBegin:
                case Event.WClientDRXStartPageBegin:
                case Event.WClientDRXEndPageBegin:
                case Event.WClientDRXCommitPageBegin:
                case Event.WClientDRXConvertFontBegin:
                case Event.WClientDRXConvertImageBegin:
                case Event.WClientDRXSaveXpsBegin:
                case Event.WClientDRXLoadPrimitiveBegin:
                case Event.WClientDRXSavePageBegin:
                case Event.WClientDRXSerializationBegin:
                case Event.WClientDRXReadStreamBegin:
                case Event.WClientDRXGetPageBegin:
                case Event.WClientDRXLayoutBegin:
                case Event.WClientTimeManagerTickBegin:
                case Event.WClientLayoutBegin:
                case Event.WClientMeasureBegin:
                case Event.WClientArrangeBegin:
                case Event.DWMDraw_ClearStart:
                case Event.LayerEventStart:
                case Event.WClientDesktopRTCreateBegin:
                case Event.WClientUceProcessQueueBegin:
                case Event.WClientUcePrecomputeBegin:
                case Event.WClientUceRenderBegin:
                case Event.WClientUcePresentBegin:
                case Event.WClientInterlockedRenderBegin:
                case Event.WClientRenderHandlerBegin:
                case Event.WClientAnimRenderHandlerBegin:
                case Event.WClientMediaRenderBegin:
                case Event.WClientPrecomputeSceneBegin:
                case Event.WClientCompileSceneBegin:
                case Event.WClientOnRenderBegin:
                case Event.WClientUIContextDispatchBegin:
                    return 1;
                case Event.WClientStringEnd:
                case Event.UpdateVisualStateEnd:
                case Event.CreateStickyNoteEnd:
                case Event.DeleteTextNoteEnd:
                case Event.DeleteInkNoteEnd:
                case Event.CreateHighlightEnd:
                case Event.ClearHighlightEnd:
                case Event.LoadAnnotationsEnd:
                case Event.AddAnnotationEnd:
                case Event.DeleteAnnotationEnd:
                case Event.GetAnnotationByIdEnd:
                case Event.GetAnnotationByLocEnd:
                case Event.GetAnnotationsEnd:
                case Event.SerializeAnnotationEnd:
                case Event.DeserializeAnnotationEnd:
                case Event.UpdateAnnotationWithSNCEnd:
                case Event.UpdateSNCWithAnnotationEnd:
                case Event.AnnotationTextChangedEnd:
                case Event.AnnotationInkChangedEnd:
                case Event.AddAttachedSNEnd:
                case Event.RemoveAttachedSNEnd:
                case Event.AddAttachedHighlightEnd:
                case Event.RemoveAttachedHighlightEnd:
                case Event.AddAttachedMHEnd:
                case Event.RemoveAttachedMHEnd:
                case Event.WClientParseBamlEnd:
                case Event.WClientParseXmlEnd:
                case Event.WClientParseFefCrInstEnd:
                case Event.WClientParseInstVisTreeEnd:
                case Event.WClientParseRdrCrInstEnd:
                case Event.WClientParseRdrCrInFTypEnd:
                case Event.WClientResourceFindEnd:
                case Event.WClientParseXamlEnd:
                case Event.WClientDRXFlushPageStop:
                case Event.WClientDRXSerializeTreeEnd:
                case Event.WClientDRXGetVisualEnd:
                case Event.WClientDRXReleaseWriterEnd:
                case Event.WClientDRXGetPrintCapEnd:
                case Event.WClientDRXPTProviderEnd:
                case Event.WClientDRXRasterEnd:
                case Event.WClientDRXOpenPackageEnd:
                case Event.WClientDRXGetStreamEnd:
                case Event.WClientDRXFindEnd:
                case Event.WClientDRXEnsureOMEnd:
                case Event.WClientDRXTreeFlattenEnd:
                case Event.WClientDRXAlphaFlattenEnd:
                case Event.WClientDRXGetDevModeEnd:
                case Event.WClientDRXStartDocEnd:
                case Event.WClientDRXEndDocEnd:
                case Event.WClientDRXStartPageEnd:
                case Event.WClientDRXEndPageEnd:
                case Event.WClientDRXCommitPageEnd:
                case Event.WClientDRXConvertFontEnd:
                case Event.WClientDRXConvertImageEnd:
                case Event.WClientDRXSaveXpsEnd:
                case Event.WClientDRXLoadPrimitiveEnd:
                case Event.WClientDRXSavePageEnd:
                case Event.WClientDRXSerializationEnd:
                case Event.WClientDRXReadStreamEnd:
                case Event.WClientDRXGetPageEnd:
                case Event.WClientDRXLayoutEnd:
                case Event.WClientTimeManagerTickEnd:
                case Event.WClientLayoutEnd:
                case Event.WClientMeasureEnd:
                case Event.WClientArrangeEnd:
                case Event.DWMDraw_ClearEnd:
                case Event.LayerEventEnd:
                case Event.WClientDesktopRTCreateEnd:
                case Event.WClientUceProcessQueueEnd:
                case Event.WClientUcePrecomputeEnd:
                case Event.WClientUceRenderEnd:
                case Event.WClientUcePresentEnd:
                case Event.WClientInterlockedRenderEnd:
                case Event.WClientRenderHandlerEnd:
                case Event.WClientAnimRenderHandlerEnd:
                case Event.WClientMediaRenderEnd:
                case Event.WClientPrecomputeSceneEnd:
                case Event.WClientCompileSceneEnd:
                case Event.WClientOnRenderEnd:
                case Event.WClientUIContextDispatchEnd:
                    return 2;
                case Event.PerfElementIDName:
                case Event.WClientMeasureAbort:
                case Event.WClientArrangeAbort:
                case Event.WClientLayoutAbort:
                case Event.WpfHost_DocObjHostCreated:
                case Event.Wpf_NavigationStart:
                    return 10;
                case Event.WClientMeasureElementBegin:
                case Event.WClientArrangeElementBegin:
                case Event.WClientLayoutFireSizeChangedBegin:
                case Event.WpfHost_IBHSRunStart:
                case Event.Wpf_NavigationAsyncWorkItem:
                    return 11;
                case Event.WClientMeasureElementEnd:
                case Event.WClientArrangeElementEnd:
                case Event.WClientLayoutFireSizeChangedEnd:
                case Event.WpfHost_IBHSRunEnd:
                case Event.Wpf_NavigationWebResponseReceived:
                    return 12;
                case Event.WClientLayoutFireLayoutUpdatedBegin:
                case Event.WpfHost_XappLauncherAppStartup:
                case Event.Wpf_NavigationLaunchBrowser:
                    return 13;
                case Event.WClientLayoutFireLayoutUpdatedEnd:
                case Event.WpfHost_XappLauncherAppExit:
                case Event.Wpf_NavigationEnd:
                    return 14;
                case Event.WClientLayoutFireAutomationEventsBegin:
                case Event.WpfHost_DocObjHostRunApplicationStart:
                case Event.Wpf_NavigationContentRendered:
                    return 15;
                case Event.WClientLayoutFireAutomationEventsEnd:
                case Event.WpfHost_DocObjHostRunApplicationEnd:
                case Event.Wpf_NavigationPageFunctionReturn:
                    return 16;
                case Event.WClientLayoutException:
                case Event.WpfHost_ClickOnceActivationStart:
                    return 17;
                case Event.WClientLayoutInvalidated:
                case Event.WpfHost_ClickOnceActivationEnd:
                    return 18;
                case Event.WpfHost_InitAppProxyStart:
                    return 19;
                case Event.WpfHost_InitAppProxyEnd:
                    return 20;
                case Event.WpfHostUm_WinMainStart:
                case Event.WpfHost_AppProxyCtor:
                    return 30;
                case Event.WpfHostUm_WinMainEnd:
                case Event.WpfHost_RootBrowserWindowSetupStart:
                    return 31;
                case Event.WpfHostUm_InvokingBrowser:
                case Event.WpfHost_RootBrowserWindowSetupEnd:
                    return 32;
                case Event.WpfHostUm_LaunchingRestrictedProcess:
                case Event.WpfHost_AppProxyRunStart:
                    return 33;
                case Event.WpfHostUm_EnteringMessageLoop:
                case Event.WpfHost_AppProxyRunEnd:
                    return 34;
                case Event.WpfHostUm_ClassFactoryCreateInstance:
                    return 35;
                case Event.WpfHostUm_ReadingDeplManifestStart:
                case Event.WpfHost_AppDomainManagerCctor:
                    return 40;
                case Event.WpfHostUm_ReadingDeplManifestEnd:
                case Event.WpfHost_ApplicationActivatorCreateInstanceStart:
                    return 41;
                case Event.WpfHostUm_ReadingAppManifestStart:
                case Event.WpfHost_ApplicationActivatorCreateInstanceEnd:
                    return 42;
                case Event.WpfHostUm_ReadingAppManifestEnd:
                case Event.WpfHost_DetermineApplicationTrustStart:
                    return 43;
                case Event.WpfHostUm_ParsingMarkupVersionStart:
                case Event.WpfHost_DetermineApplicationTrustEnd:
                    return 44;
                case Event.WpfHostUm_ParsingMarkupVersionEnd:
                    return 45;
                case Event.WpfHostUm_IPersistFileLoad:
                case Event.WpfHost_FirstTimeActivation:
                    return 50;
                case Event.WpfHostUm_IPersistMonikerLoadStart:
                case Event.WpfHost_GetDownloadPageStart:
                    return 51;
                case Event.WpfHostUm_IPersistMonikerLoadEnd:
                case Event.WpfHost_GetDownloadPageEnd:
                    return 52;
                case Event.WpfHostUm_BindProgress:
                case Event.WpfHost_DownloadDeplManifestStart:
                    return 53;
                case Event.WpfHostUm_OnStopBinding:
                case Event.WpfHost_DownloadDeplManifestEnd:
                    return 54;
                case Event.WpfHost_AssertAppRequirementsStart:
                    return 55;
                case Event.WpfHost_AssertAppRequirementsEnd:
                case Event.DWMDraw_BitmapStart:
                    return 56;
                case Event.WpfHost_DownloadApplicationStart:
                case Event.DWMDraw_BitmapEnd:
                    return 57;
                case Event.WpfHost_DownloadApplicationEnd:
                case Event.DWMDraw_RectangleStart:
                    return 58;
                case Event.WpfHost_DownloadProgressUpdate:
                case Event.DWMDraw_RectangleEnd:
                    return 59;
                case Event.WpfHostUm_VersionAttach:
                case Event.WpfHost_XappLauncherAppNavigated:
                case Event.DWMDraw_GeometryStart:
                    return 60;
                case Event.WpfHostUm_VersionActivateStart:
                case Event.DWMDraw_GeometryEnd:
                    return 61;
                case Event.WpfHostUm_VersionActivateEnd:
                case Event.DWMDraw_ImageStart:
                    return 62;
                case Event.DWMDraw_ImageEnd:
                    return 63;
                case Event.DWMDraw_GlyphRunStart:
                    return 64;
                case Event.DWMDraw_GlyphRunEnd:
                    return 65;
                case Event.DWMDraw_BeginLayerStart:
                    return 68;
                case Event.DWMDraw_BeginLayerEnd:
                    return 69;
                case Event.WpfHost_UpdateBrowserCommandsStart:
                case Event.DWMDraw_EndLayerStart:
                    return 70;
                case Event.WpfHost_UpdateBrowserCommandsEnd:
                case Event.DWMDraw_EndLayerEnd:
                    return 71;
                case Event.DWMDraw_ClippedBitmapStart:
                    return 78;
                case Event.DWMDraw_ClippedBitmapEnd:
                    return 79;
                case Event.WpfHost_PostShutdown:
                    return 80;
                case Event.WpfHost_AbortingActivation:
                    return 81;
                case Event.WpfHostUm_StartingCLRStart:
                    return 90;
                case Event.WpfHostUm_StartingCLREnd:
                    return 91;
                case Event.WpfHostUm_IHlinkTargetNavigateStart:
                    return 95;
                case Event.WpfHostUm_IHlinkTargetNavigateEnd:
                    return 96;
                case Event.WpfHostUm_ReadyStateChanged:
                    return 97;
                case Event.WpfHostUm_InitDocHostStart:
                    return 98;
                case Event.WpfHostUm_InitDocHostEnd:
                    return 99;
                case Event.WpfHostUm_MergingMenusStart:
                    return 100;
                case Event.WpfHostUm_MergingMenusEnd:
                    return 101;
                case Event.WpfHostUm_UIActivationStart:
                    return 102;
                case Event.WpfHostUm_UIActivationEnd:
                    return 103;
                case Event.WpfHostUm_LoadingResourceDLLStart:
                    return 104;
                case Event.WpfHostUm_LoadingResourceDLLEnd:
                    return 105;
                case Event.WpfHostUm_OleCmdQueryStatusStart:
                    return 106;
                case Event.WpfHostUm_OleCmdQueryStatusEnd:
                    return 107;
                case Event.WpfHostUm_OleCmdExecStart:
                    return 108;
                case Event.WpfHostUm_OleCmdExecEnd:
                    return 109;
                case Event.WpfHostUm_ProgressPageShown:
                    return 110;
                case Event.WpfHostUm_AdHocProfile1Start:
                    return 152;
                case Event.WpfHostUm_AdHocProfile1End:
                    return 153;
                case Event.WpfHostUm_AdHocProfile2Start:
                    return 154;
                case Event.WpfHostUm_AdHocProfile2End:
                    return 155;
                default: throw new ArgumentException(Strings.InvalidEvent, nameof(arg));
            }
        }

        internal static byte GetVersionForEvent(Event arg)
        {
            switch (arg)
            {
                case Event.UpdateVisualStateStart:
                case Event.UpdateVisualStateEnd:
                case Event.PerfElementIDName:
                case Event.PerfElementIDAssignment:
                case Event.StylusEventQueued:
                case Event.TouchDownReported:
                case Event.TouchMoveReported:
                case Event.TouchUpReported:
                case Event.ManipulationReportFrame:
                case Event.ManipulationEventRaised:
                case Event.PenThreadPoolThreadAcquisition:
                case Event.WClientParseXamlBegin:
                case Event.WClientParseXamlBamlInfo:
                case Event.WClientParseXamlEnd:
                case Event.WClientDRXFlushPageStart:
                case Event.WClientDRXFlushPageStop:
                case Event.WClientDRXSerializeTreeStart:
                case Event.WClientDRXSerializeTreeEnd:
                case Event.WClientDRXGetVisualStart:
                case Event.WClientDRXGetVisualEnd:
                case Event.WClientDRXReleaseWriterStart:
                case Event.WClientDRXReleaseWriterEnd:
                case Event.WClientDRXGetPrintCapStart:
                case Event.WClientDRXGetPrintCapEnd:
                case Event.WClientDRXPTProviderStart:
                case Event.WClientDRXPTProviderEnd:
                case Event.WClientDRXRasterStart:
                case Event.WClientDRXRasterEnd:
                case Event.WClientMeasureAbort:
                case Event.WClientMeasureElementBegin:
                case Event.WClientMeasureElementEnd:
                case Event.WClientArrangeElementBegin:
                case Event.WClientArrangeElementEnd:
                case Event.WClientLayoutAbort:
                case Event.WClientLayoutFireSizeChangedBegin:
                case Event.WClientLayoutFireSizeChangedEnd:
                case Event.WClientLayoutFireLayoutUpdatedBegin:
                case Event.WClientLayoutFireLayoutUpdatedEnd:
                case Event.WClientLayoutFireAutomationEventsBegin:
                case Event.WClientLayoutFireAutomationEventsEnd:
                case Event.WClientLayoutException:
                case Event.WClientLayoutInvalidated:
                case Event.DrawBitmapInfo:
                case Event.BitmapCopyInfo:
                case Event.SetClipInfo:
                case Event.DWMDraw_ClearStart:
                case Event.DWMDraw_ClearEnd:
                case Event.DWMDraw_BitmapStart:
                case Event.DWMDraw_BitmapEnd:
                case Event.DWMDraw_RectangleStart:
                case Event.DWMDraw_RectangleEnd:
                case Event.DWMDraw_GeometryStart:
                case Event.DWMDraw_GeometryEnd:
                case Event.DWMDraw_ImageStart:
                case Event.DWMDraw_ImageEnd:
                case Event.DWMDraw_GlyphRunStart:
                case Event.DWMDraw_GlyphRunEnd:
                case Event.DWMDraw_BeginLayerStart:
                case Event.DWMDraw_BeginLayerEnd:
                case Event.DWMDraw_EndLayerStart:
                case Event.DWMDraw_EndLayerEnd:
                case Event.DWMDraw_ClippedBitmapStart:
                case Event.DWMDraw_ClippedBitmapEnd:
                case Event.DWMDraw_Info:
                case Event.VisualCacheAlloc:
                case Event.VisualCacheUpdate:
                case Event.CreateChannel:
                case Event.CreateOrAddResourceOnChannel:
                case Event.CreateWpfGfxResource:
                case Event.ReleaseOnChannel:
                case Event.UnexpectedSoftwareFallback:
                case Event.WClientOnRenderBegin:
                case Event.WClientOnRenderEnd:
                case Event.WClientCreateIRT:
                case Event.WClientPotentialIRTResource:
                    return 0;
                case Event.WClientCreateVisual:
                case Event.WClientAppCtor:
                case Event.WClientAppRun:
                case Event.WClientString:
                case Event.WClientStringBegin:
                case Event.WClientStringEnd:
                case Event.WClientPropParentCheck:
                case Event.WClientFontCache:
                case Event.WClientInputMessage:
                case Event.CreateStickyNoteBegin:
                case Event.CreateStickyNoteEnd:
                case Event.DeleteTextNoteBegin:
                case Event.DeleteTextNoteEnd:
                case Event.DeleteInkNoteBegin:
                case Event.DeleteInkNoteEnd:
                case Event.CreateHighlightBegin:
                case Event.CreateHighlightEnd:
                case Event.ClearHighlightBegin:
                case Event.ClearHighlightEnd:
                case Event.LoadAnnotationsBegin:
                case Event.LoadAnnotationsEnd:
                case Event.AddAnnotationBegin:
                case Event.AddAnnotationEnd:
                case Event.DeleteAnnotationBegin:
                case Event.DeleteAnnotationEnd:
                case Event.GetAnnotationByIdBegin:
                case Event.GetAnnotationByIdEnd:
                case Event.GetAnnotationByLocBegin:
                case Event.GetAnnotationByLocEnd:
                case Event.GetAnnotationsBegin:
                case Event.GetAnnotationsEnd:
                case Event.SerializeAnnotationBegin:
                case Event.SerializeAnnotationEnd:
                case Event.DeserializeAnnotationBegin:
                case Event.DeserializeAnnotationEnd:
                case Event.UpdateAnnotationWithSNCBegin:
                case Event.UpdateAnnotationWithSNCEnd:
                case Event.UpdateSNCWithAnnotationBegin:
                case Event.UpdateSNCWithAnnotationEnd:
                case Event.AnnotationTextChangedBegin:
                case Event.AnnotationTextChangedEnd:
                case Event.AnnotationInkChangedBegin:
                case Event.AnnotationInkChangedEnd:
                case Event.AddAttachedSNBegin:
                case Event.AddAttachedSNEnd:
                case Event.RemoveAttachedSNBegin:
                case Event.RemoveAttachedSNEnd:
                case Event.AddAttachedHighlightBegin:
                case Event.AddAttachedHighlightEnd:
                case Event.RemoveAttachedHighlightBegin:
                case Event.RemoveAttachedHighlightEnd:
                case Event.AddAttachedMHBegin:
                case Event.AddAttachedMHEnd:
                case Event.RemoveAttachedMHBegin:
                case Event.RemoveAttachedMHEnd:
                case Event.WClientParseBamlBegin:
                case Event.WClientParseBamlEnd:
                case Event.WClientParseXmlBegin:
                case Event.WClientParseXmlEnd:
                case Event.WClientParseFefCrInstBegin:
                case Event.WClientParseFefCrInstEnd:
                case Event.WClientParseInstVisTreeBegin:
                case Event.WClientParseInstVisTreeEnd:
                case Event.WClientParseRdrCrInstBegin:
                case Event.WClientParseRdrCrInstEnd:
                case Event.WClientParseRdrCrInFTypBegin:
                case Event.WClientParseRdrCrInFTypEnd:
                case Event.WClientResourceFindBegin:
                case Event.WClientResourceFindEnd:
                case Event.WClientResourceCacheValue:
                case Event.WClientResourceCacheNull:
                case Event.WClientResourceCacheMiss:
                case Event.WClientResourceStock:
                case Event.WClientResourceBamlAssembly:
                case Event.WClientDRXOpenPackageBegin:
                case Event.WClientDRXOpenPackageEnd:
                case Event.WClientDRXGetStreamBegin:
                case Event.WClientDRXGetStreamEnd:
                case Event.WClientDRXPageVisible:
                case Event.WClientDRXPageLoaded:
                case Event.WClientDRXInvalidateView:
                case Event.WClientDRXStyleCreated:
                case Event.WClientDRXFindBegin:
                case Event.WClientDRXFindEnd:
                case Event.WClientDRXZoom:
                case Event.WClientDRXEnsureOMBegin:
                case Event.WClientDRXEnsureOMEnd:
                case Event.WClientDRXTreeFlattenBegin:
                case Event.WClientDRXTreeFlattenEnd:
                case Event.WClientDRXAlphaFlattenBegin:
                case Event.WClientDRXAlphaFlattenEnd:
                case Event.WClientDRXGetDevModeBegin:
                case Event.WClientDRXGetDevModeEnd:
                case Event.WClientDRXStartDocBegin:
                case Event.WClientDRXStartDocEnd:
                case Event.WClientDRXEndDocBegin:
                case Event.WClientDRXEndDocEnd:
                case Event.WClientDRXStartPageBegin:
                case Event.WClientDRXStartPageEnd:
                case Event.WClientDRXEndPageBegin:
                case Event.WClientDRXEndPageEnd:
                case Event.WClientDRXCommitPageBegin:
                case Event.WClientDRXCommitPageEnd:
                case Event.WClientDRXConvertFontBegin:
                case Event.WClientDRXConvertFontEnd:
                case Event.WClientDRXConvertImageBegin:
                case Event.WClientDRXConvertImageEnd:
                case Event.WClientDRXSaveXpsBegin:
                case Event.WClientDRXSaveXpsEnd:
                case Event.WClientDRXLoadPrimitiveBegin:
                case Event.WClientDRXLoadPrimitiveEnd:
                case Event.WClientDRXSavePageBegin:
                case Event.WClientDRXSavePageEnd:
                case Event.WClientDRXSerializationBegin:
                case Event.WClientDRXSerializationEnd:
                case Event.WClientDRXReadStreamBegin:
                case Event.WClientDRXReadStreamEnd:
                case Event.WClientDRXGetPageBegin:
                case Event.WClientDRXGetPageEnd:
                case Event.WClientDRXLineDown:
                case Event.WClientDRXPageDown:
                case Event.WClientDRXPageJump:
                case Event.WClientDRXLayoutBegin:
                case Event.WClientDRXLayoutEnd:
                case Event.WClientDRXInstantiated:
                case Event.WClientTimeManagerTickBegin:
                case Event.WClientTimeManagerTickEnd:
                case Event.WClientLayoutEnd:
                case Event.WClientMeasureBegin:
                case Event.WClientMeasureEnd:
                case Event.WClientArrangeBegin:
                case Event.WClientArrangeAbort:
                case Event.WClientArrangeEnd:
                case Event.WpfHostUm_WinMainStart:
                case Event.WpfHostUm_WinMainEnd:
                case Event.WpfHostUm_InvokingBrowser:
                case Event.WpfHostUm_LaunchingRestrictedProcess:
                case Event.WpfHostUm_EnteringMessageLoop:
                case Event.WpfHostUm_ClassFactoryCreateInstance:
                case Event.WpfHostUm_ReadingDeplManifestStart:
                case Event.WpfHostUm_ReadingDeplManifestEnd:
                case Event.WpfHostUm_ReadingAppManifestStart:
                case Event.WpfHostUm_ReadingAppManifestEnd:
                case Event.WpfHostUm_ParsingMarkupVersionStart:
                case Event.WpfHostUm_ParsingMarkupVersionEnd:
                case Event.WpfHostUm_IPersistFileLoad:
                case Event.WpfHostUm_IPersistMonikerLoadStart:
                case Event.WpfHostUm_IPersistMonikerLoadEnd:
                case Event.WpfHostUm_BindProgress:
                case Event.WpfHostUm_OnStopBinding:
                case Event.WpfHostUm_VersionAttach:
                case Event.WpfHostUm_VersionActivateStart:
                case Event.WpfHostUm_VersionActivateEnd:
                case Event.WpfHostUm_StartingCLRStart:
                case Event.WpfHostUm_StartingCLREnd:
                case Event.WpfHostUm_IHlinkTargetNavigateStart:
                case Event.WpfHostUm_IHlinkTargetNavigateEnd:
                case Event.WpfHostUm_ReadyStateChanged:
                case Event.WpfHostUm_InitDocHostStart:
                case Event.WpfHostUm_InitDocHostEnd:
                case Event.WpfHostUm_MergingMenusStart:
                case Event.WpfHostUm_MergingMenusEnd:
                case Event.WpfHostUm_UIActivationStart:
                case Event.WpfHostUm_UIActivationEnd:
                case Event.WpfHostUm_LoadingResourceDLLStart:
                case Event.WpfHostUm_LoadingResourceDLLEnd:
                case Event.WpfHostUm_OleCmdQueryStatusStart:
                case Event.WpfHostUm_OleCmdQueryStatusEnd:
                case Event.WpfHostUm_OleCmdExecStart:
                case Event.WpfHostUm_OleCmdExecEnd:
                case Event.WpfHostUm_ProgressPageShown:
                case Event.WpfHostUm_AdHocProfile1Start:
                case Event.WpfHostUm_AdHocProfile1End:
                case Event.WpfHostUm_AdHocProfile2Start:
                case Event.WpfHostUm_AdHocProfile2End:
                case Event.WpfHost_DocObjHostCreated:
                case Event.WpfHost_XappLauncherAppStartup:
                case Event.WpfHost_XappLauncherAppExit:
                case Event.WpfHost_DocObjHostRunApplicationStart:
                case Event.WpfHost_DocObjHostRunApplicationEnd:
                case Event.WpfHost_ClickOnceActivationStart:
                case Event.WpfHost_ClickOnceActivationEnd:
                case Event.WpfHost_InitAppProxyStart:
                case Event.WpfHost_InitAppProxyEnd:
                case Event.WpfHost_AppProxyCtor:
                case Event.WpfHost_RootBrowserWindowSetupStart:
                case Event.WpfHost_RootBrowserWindowSetupEnd:
                case Event.WpfHost_AppProxyRunStart:
                case Event.WpfHost_AppProxyRunEnd:
                case Event.WpfHost_AppDomainManagerCctor:
                case Event.WpfHost_ApplicationActivatorCreateInstanceStart:
                case Event.WpfHost_ApplicationActivatorCreateInstanceEnd:
                case Event.WpfHost_DetermineApplicationTrustStart:
                case Event.WpfHost_DetermineApplicationTrustEnd:
                case Event.WpfHost_FirstTimeActivation:
                case Event.WpfHost_GetDownloadPageStart:
                case Event.WpfHost_GetDownloadPageEnd:
                case Event.WpfHost_DownloadDeplManifestStart:
                case Event.WpfHost_DownloadDeplManifestEnd:
                case Event.WpfHost_AssertAppRequirementsStart:
                case Event.WpfHost_AssertAppRequirementsEnd:
                case Event.WpfHost_DownloadApplicationStart:
                case Event.WpfHost_DownloadApplicationEnd:
                case Event.WpfHost_DownloadProgressUpdate:
                case Event.WpfHost_XappLauncherAppNavigated:
                case Event.WpfHost_UpdateBrowserCommandsStart:
                case Event.WpfHost_UpdateBrowserCommandsEnd:
                case Event.WpfHost_PostShutdown:
                case Event.WpfHost_AbortingActivation:
                case Event.WpfHost_IBHSRunStart:
                case Event.WpfHost_IBHSRunEnd:
                case Event.Wpf_NavigationAsyncWorkItem:
                case Event.Wpf_NavigationWebResponseReceived:
                case Event.Wpf_NavigationEnd:
                case Event.Wpf_NavigationContentRendered:
                case Event.Wpf_NavigationStart:
                case Event.Wpf_NavigationLaunchBrowser:
                case Event.Wpf_NavigationPageFunctionReturn:
                case Event.LayerEventStart:
                case Event.LayerEventEnd:
                case Event.WClientDesktopRTCreateBegin:
                case Event.WClientDesktopRTCreateEnd:
                case Event.WClientUceProcessQueueBegin:
                case Event.WClientUceProcessQueueEnd:
                case Event.WClientUceProcessQueueInfo:
                case Event.WClientUcePrecomputeBegin:
                case Event.WClientUcePrecomputeEnd:
                case Event.WClientUceRenderBegin:
                case Event.WClientUceRenderEnd:
                case Event.WClientUcePresentBegin:
                case Event.WClientUcePresentEnd:
                case Event.WClientUceResponse:
                case Event.WClientUceCheckDeviceStateInfo:
                case Event.WClientInterlockedRenderBegin:
                case Event.WClientInterlockedRenderEnd:
                case Event.WClientRenderHandlerBegin:
                case Event.WClientRenderHandlerEnd:
                case Event.WClientAnimRenderHandlerBegin:
                case Event.WClientAnimRenderHandlerEnd:
                case Event.WClientMediaRenderBegin:
                case Event.WClientMediaRenderEnd:
                case Event.WClientPostRender:
                case Event.WClientQPCFrequency:
                case Event.WClientPrecomputeSceneBegin:
                case Event.WClientPrecomputeSceneEnd:
                case Event.WClientCompileSceneBegin:
                case Event.WClientCompileSceneEnd:
                case Event.WClientUIResponse:
                case Event.WClientUICommitChannel:
                case Event.WClientUceNotifyPresent:
                case Event.WClientScheduleRender:
                case Event.WClientUIContextDispatchEnd:
                case Event.WClientUIContextIdle:
                    return 2;
                case Event.WClientLayoutBegin:
                case Event.WClientUIContextDispatchBegin:
                case Event.WClientUIContextPost:
                case Event.WClientUIContextAbort:
                case Event.WClientUIContextPromote:
                    return 3;
                default: throw new ArgumentException(Strings.InvalidEvent, nameof(arg));
            }
        }

        static readonly internal TraceProvider EventProvider;

        // EasyTraceEvent
        // Checks the keyword and level before emiting the event
        static internal void EasyTraceEvent(Keyword keywords, Event eventID)
        {
            if (IsEnabled(keywords, Level.Info))
            {
                EventProvider.TraceEvent(eventID, keywords, Level.Info);
            }
        }

        // EasyTraceEvent
        // Checks the keyword and level before emiting the event
        static internal void EasyTraceEvent(Keyword keywords, Level level, Event eventID)
        {
            if (IsEnabled(keywords, level))
            {
                EventProvider.TraceEvent(eventID, keywords, level);
            }
        }

        // EasyTraceEvent
        // Checks the keyword and level before emiting the event
        static internal void EasyTraceEvent<T1>(Keyword keywords, Event eventID, T1 param1)
        {
            if (IsEnabled(keywords, Level.Info))
            {
                EventProvider.TraceEvent(eventID, keywords, Level.Info, param1);
            }
        }

        // EasyTraceEvent
        // Checks the keyword and level before emiting the event
        static internal void EasyTraceEvent<T1>(Keyword keywords, Level level, Event eventID, T1 param1)
        {
            if (IsEnabled(keywords, level))
            {
                EventProvider.TraceEvent(eventID, keywords, level, param1);
            }
        }

        // EasyTraceEvent
        // Checks the keyword and level before emiting the event
        static internal void EasyTraceEvent<T1, T2>(Keyword keywords, Event eventID, T1 param1, T2 param2)
        {
            if (IsEnabled(keywords, Level.Info))
            {
                EventProvider.TraceEvent(eventID, keywords, Level.Info, param1, param2);
            }
        }

        static internal void EasyTraceEvent<T1, T2>(Keyword keywords, Level level, Event eventID, T1 param1, T2 param2)
        {
            if (IsEnabled(keywords, Level.Info))
            {
                EventProvider.TraceEvent(eventID, keywords, Level.Info, param1, param2);
            }
        }

        // EasyTraceEvent
        // Checks the keyword and level before emiting the event
        static internal void EasyTraceEvent<T1, T2, T3>(Keyword keywords, Event eventID, T1 param1, T2 param2, T3 param3)
        {
            if (IsEnabled(keywords, Level.Info))
            {
                EventProvider.TraceEvent(eventID, keywords, Level.Info, param1, param2, param3);
            }
        }

        #region Trace related enumerations
        public enum LayoutSource : byte
        {
            LayoutManager,
            HwndSource_SetLayoutSize,
            HwndSource_WMSIZE
        }
        #endregion

        /// <summary>
        /// Callers use this to check if they should be logging.
        /// </summary>
        static internal bool IsEnabled(Keyword flag, Level level)
        {
            return EventProvider.IsEnabled(flag, level);
        }

        /// <summary>
        /// Internal operations associated with initializing the event provider and
        /// monitoring the Dispatcher and input components.
        /// </summary>
        static EventTrace()
        {
            var providerGuid = new Guid("E13B77A8-14B6-11DE-8069-001B212B5009");

            if (Environment.OSVersion.Version.Major < 6 ||
                IsClassicETWRegistryEnabled())
            {
                EventProvider = new ClassicTraceProvider();
            }
            else
            {
                EventProvider = new ManifestTraceProvider();
            }
            EventProvider.Register(providerGuid);
        }

        static bool IsClassicETWRegistryEnabled()
        {
            string regKey = @"HKEY_CURRENT_USER\Software\Microsoft\Avalon.Graphics\";
            return Equals(1, Microsoft.Win32.Registry.GetValue(regKey, "ClassicETW", 0));
        }
    }
}
