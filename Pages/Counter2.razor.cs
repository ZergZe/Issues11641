using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;

namespace SomeNameSpace
{
    public partial class Counter2Base : ComponentBase, IDisposable
    {
        public ElementRef input;
        public string Text;

        [Inject] IJSRuntime JsRuntime { get; set; }
        [Inject] IComponentContext ComponentContext { get; set; }

        object objReg;
        object ObjReg {
            get {
                if (objReg == null)
                    objReg = DotNetObjectRef.Create(this);
                return objReg;
            }
        }

        protected override void OnAfterRender()
        {
            SubscribeEvents();
        }

        public async void SubscribeEvents()
        {
            JSRuntime.SetCurrentJSRuntime(JsRuntime);
            await JsRuntime.InvokeAsync<object>(
                    "exampleJsFunctions.SubscribeEvents", input, ObjReg);
        }

        [JSInvokable]
        public void LostFocus(string text)
        {
            Text = text;
            StateHasChanged();
        }

        public void Dispose()
        {
            var disposableObjReg = objReg as IDisposable;
            if(disposableObjReg != null)
                disposableObjReg.Dispose();
        }
    }
}