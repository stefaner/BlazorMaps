﻿using FisSst.Maps.JsInterops.Base;
using FisSst.Maps.Models;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.Maps.JsInterops
{
    class EventedJsInterop : BaseJsInterop, IEventedJsInterop
    {
        private static readonly string jsFilePath = $"{JsInteropConfig.BaseJsFolder}{JsInteropConfig.EventedFile}";
        private const string onCallback = "onCallback";

        public EventedJsInterop(IJSRuntime jsRuntime) : base(jsRuntime, jsFilePath)
        {

        }

        public async ValueTask OnCallback(
            DotNetObjectReference<Evented> eventedClass, 
            JSObjectReference evented, 
            string eventType)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(onCallback, eventedClass, evented, eventType);
        }
    }
}
