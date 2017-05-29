
(function ($) {
    app.modals.CreateOrEditT_ContentModal = function () {

        var _modalManager;

        var _t_ContentService = abp.services.app.t_Content;

		$(".maxlength-handler").maxlength({
            limitReachedClass: "label label-danger",
            alwaysShow: true,
            threshold: 5,
            placement: 'bottom'
        });

        var _$t_ContentInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
			            _$t_ContentInformationForm = _modalManager.getModal().find("form[name=t_ContentInformationsForm]");

						
			 
			   	 


						
			 
			   	 


			
			
      


        }
        
        this.save = function () {
            if (!_$t_ContentInformationForm.valid()) {
                return;
            }
            //校验通过

            var t_Content = _$t_ContentInformationForm.serializeFormToObject();
          //  console.log(t_Content);

            _modalManager.setBusy(true);

            _t_ContentService.createOrUpdateT_ContentAsync({
                t_ContentEditDto: t_Content
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                //信息保存成功后调用事件，刷新列表
                abp.event.trigger('app.createOrEditT_ContentModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);

   