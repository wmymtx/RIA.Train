
(function ($) {
    app.modals.CreateOrEditT_GroupModal = function () {

        var _modalManager;

        var _t_GroupService = abp.services.app.t_Group;

		$(".maxlength-handler").maxlength({
            limitReachedClass: "label label-danger",
            alwaysShow: true,
            threshold: 5,
            placement: 'bottom'
        });

        var _$t_GroupInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
			            _$t_GroupInformationForm = _modalManager.getModal().find("form[name=t_GroupInformationsForm]");

						
			 
			   	 


						
			 
			   	      
								 //渲染select
								    $("#fK_DepIdEdit").selectpicker();



						
			 
			   	 


			
			
      


        }
        
        this.save = function () {
            if (!_$t_GroupInformationForm.valid()) {
                return;
            }
            //校验通过

            var t_Group = _$t_GroupInformationForm.serializeFormToObject();
          //  console.log(t_Group);

            _modalManager.setBusy(true);

            _t_GroupService.createOrUpdateT_GroupAsync({
                t_GroupEditDto: t_Group
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                //信息保存成功后调用事件，刷新列表
                abp.event.trigger('app.createOrEditT_GroupModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);

   