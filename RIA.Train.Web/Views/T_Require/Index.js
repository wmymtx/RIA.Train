


(function () {
    $(function () {

        var _$t_RequiresTable = $('#T_RequiresTable');
        var _t_RequireService = abp.services.app.t_Require;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.T_Require.CreateT_Require"),
            edit: abp.auth.hasPermission("Pages.T_Require.EditT_Require"),
            'delete': abp.auth.hasPermission("Pages.T_Require.DeleteT_Require")

        };


      var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'T_Require/CreateOrEditT_RequireModal',
            scriptUrl: abp.appPath + 'Views/T_Require/_CreateOrEditT_RequireModal.js',
            modalClass: 'CreateOrEditT_RequireModal'
        });

    



        _$t_RequiresTable.jtable({

            title: app.localize('T_Require'),
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
                listAction: _t_RequireService.getPagedT_RequiresAsync
        
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
                                deleteT_Require(data.record);
                            });
                    }
                    //添加
                    if (_permissions.create) {
                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("CreateT_Require") + "' ><i class='fa fa-plus'></i></button>")
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

fk_Id: {
            title: app.localize('Fk_Id'),
            width: '10%'
         },     
	  

fk_UserId: {
            title: app.localize('Fk_UserId'),
            width: '10%'
         },     
	  

userName: {
            title: app.localize('UserName'),
            width: '10%'
         },     
	  

content: {
            title: app.localize('Content'),
            width: '10%'
         },     
	  

submitTime: {
            title: app.localize('SubmitTime'),
            width: '10%'
         },     
	 
            }

        });

		
				   //打开添加窗口SPA
        $('#CreateNewT_RequireButton').click(function () {
            //可选生成的对话框大小{size:'lg'}or{size:'sm'}
            //需要到_createContainer方法中添加,_args.size
            _createOrEditModal.open();
        });
 



        //刷新表格信息
        $("#ButtonReload").click(function () {
            getT_Requires();
        });




//模糊查询功能
function getT_Requires(reload) {
    if (reload) {
        _$t_RequiresTable.jtable('reload');
    } else {
        _$t_RequiresTable.jtable('load', {
            filtertext: $('#T_RequiresTableFilter').val()
        });
    }
}
//
//删除当前t_Require实体
function deleteT_Require(t_Require) {   
    abp.message.confirm(
        app.localize('T_RequireDeleteWarningMessage', t_Require. fk_Id),
            function (isConfirmed) {
                if (isConfirmed) {
                    _t_RequireService.deleteT_RequireAsync({
                        id: t_Require.id
                        }).done(function () {
                            getT_Requires(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                }
            }
        );
}

 

//导出为excel文档
$('#ExportT_RequiresToExcelButton').click(function () {
    _t_RequireService
        .getT_RequiresToExcel({})
            .done(function (result) {
                app.downloadTempFile(result);
            });
});
//搜索
$('#GetT_RequiresButton').click(function (e) {
    e.preventDefault();
    getT_Requires();
});

//制作T_Require事件,用于请求变化后，刷新表格信息
abp.event.on('app.createOrEditT_RequireModalSaved', function () {
    getT_Requires(true);
});

getT_Requires();
 
 
    });
})();
