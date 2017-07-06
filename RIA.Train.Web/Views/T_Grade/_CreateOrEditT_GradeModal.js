app = app || {};
app.modals = app.modals || {};
(function ($) {
    app.modals.CreateOrEditT_GradeModal = function () {

        var _modalManager;

        var _t_GradeService = abp.services.app.t_Grade;

		$(".maxlength-handler").maxlength({
            limitReachedClass: "label label-danger",
            alwaysShow: true,
            threshold: 5,
            placement: 'bottom'
        });

        var _$t_GradeInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
			            _$t_GradeInformationForm = _modalManager.getModal().find("form[name=t_GradeInformationsForm]");

						
			 
			   	 


						
			 
			   	 


			
			
      


        }
        
        this.save = function () {
            if (!_$t_GradeInformationForm.valid()) {
                return;
            }
            //校验通过

            var t_Grade = _$t_GradeInformationForm.serializeFormToObject();
          //  console.log(t_Grade);

            _modalManager.setBusy(true);

            _t_GradeService.createOrUpdateT_GradeAsync({
                t_GradeEditDto: t_Grade
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                //信息保存成功后调用事件，刷新列表
                abp.event.trigger('app.createOrEditT_GradeModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);

   