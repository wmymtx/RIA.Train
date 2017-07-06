
 app = app || {};
app.modals = app.modals || {};
(function ($) {
    app.modals.CreateOrEditT_DepModal = function () {

        var _modalManager;

        var _t_DepService = abp.services.app.t_Dep;

		$(".maxlength-handler").maxlength({
            limitReachedClass: "label label-danger",
            alwaysShow: true,
            threshold: 5,
            placement: 'bottom'
        });

        var _$t_DepInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
			            _$t_DepInformationForm = _modalManager.getModal().find("form[name=t_DepInformationsForm]");

						
			 
			   	 


						
			 
			   	 


			
			
      


        }
        
        this.save = function () {
            if (!_$t_DepInformationForm.valid()) {
                return;
            }
            //校验通过

            var t_Dep = _$t_DepInformationForm.serializeFormToObject();
          //  console.log(t_Dep);

            _modalManager.setBusy(true);

            _t_DepService.createOrUpdateT_DepAsync({
                t_DepEditDto: t_Dep
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                //信息保存成功后调用事件，刷新列表
                abp.event.trigger('app.createOrEditT_DepModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);

   