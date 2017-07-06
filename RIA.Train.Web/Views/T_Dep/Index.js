


(function () {
    $(function () {

        var _$t_DepsTable = $('#T_DepsTable');
        var _t_DepService = abp.services.app.t_Dep;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.T_Dep.CreateT_Dep"),
            edit: abp.auth.hasPermission("Pages.T_Dep.EditT_Dep"),
            'delete': abp.auth.hasPermission("Pages.T_Dep.DeleteT_Dep")

        };


      var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'T_Dep/CreateOrEditT_DepModal',
            scriptUrl:  '/Views/T_Dep/_CreateOrEditT_DepModal.js',
            modalClass: 'CreateOrEditT_DepModal'
        });

    



        _$t_DepsTable.jtable({

            title: app.localize('T_Dep'),
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
        //        listAction: {
        //            method: _t_DepService.getPagedT_DepsAsync
        //}
                listAction: _t_DepService.getPagedT_DepsAsync
            },

        fields: {
           
            actions: {
                title: app.localize('Actions'),
                width: '10%',
                sorting: false,
                display: function (data) {
                    var $span = $('<span></span>');
                    //编辑
                    if (_permissions.edit) {
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('Edit') + '"><i class="fa fa-edit"></i></button>')
                            .appendTo($span)
                            .click(function () {
 _createOrEditModal.open({ id: data.record.id });                            });
                    }
                    //删除
                    if (_permissions.delete) {
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('Delete') + '"><i class="fa fa-trash-o"></i></button>')
                            .appendTo($span)
                            .click(function () {
                                deleteT_Dep(data.record);
                            });
                    }
                    //添加
                    if (_permissions.create) {
                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("CreateT_Dep") + "' ><i class='fa fa-plus'></i></button>")
                            .appendTo($span)
                            .click(function () {
							 _createOrEditModal.open();				                  

                            });
                    }

                    return $span;
            }
        },
		//此处开始循环数据

	 

          id: {           
                 key: true,
                list: false
         }, 	  

depName: {
            title: app.localize('DepName'),
            width: '10%'
         },     
	 
            }

        });

		
				   //打开添加窗口SPA
        $('#CreateNewT_DepButton').click(function () {
            //可选生成的对话框大小{size:'lg'}or{size:'sm'}
            //需要到_createContainer方法中添加,_args.size
            _createOrEditModal.open();
        });
 



        //刷新表格信息
        $("#ButtonReload").click(function () {
            getT_Deps();
        });




//模糊查询功能
function getT_Deps(reload) {
    if (reload) {
        _$t_DepsTable.jtable('reload');
    } else {
        _$t_DepsTable.jtable('load', {
            filtertext: $('#T_DepsTableFilter').val()
        });
    }
}
//
//删除当前t_Dep实体
function deleteT_Dep(t_Dep) {   
    abp.message.confirm(
        app.localize('T_DepDeleteWarningMessage', t_Dep. depName),
            function (isConfirmed) {
                if (isConfirmed) {
                    _t_DepService.deleteT_DepAsync({
                        id: t_Dep.id
                        }).done(function () {
                            getT_Deps(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                }
            }
        );
}

 

//导出为excel文档
$('#ExportT_DepsToExcelButton').click(function () {
    _t_DepService
        .getT_DepsToExcel({})
            .done(function (result) {
                app.downloadTempFile(result);
            });
});
//搜索
$('#GetT_DepsButton').click(function (e) {
    e.preventDefault();
    getT_Deps();
});

//制作T_Dep事件,用于请求变化后，刷新表格信息
abp.event.on('app.createOrEditT_DepModalSaved', function () {
    getT_Deps(true);
});

getT_Deps();
 
 
    });
})();
