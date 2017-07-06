


(function () {
    $(function () {

        var _$t_HClasssTable = $('#T_HClasssTable');
        var _t_HClassService = abp.services.app.t_HClass;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.T_HClass.CreateT_HClass"),
            edit: abp.auth.hasPermission("Pages.T_HClass.EditT_HClass"),
            'delete': abp.auth.hasPermission("Pages.T_HClass.DeleteT_HClass")

        };


      var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'T_HClass/CreateOrEditT_HClassModal',
            scriptUrl: 'Views/T_HClass/_CreateOrEditT_HClassModal.js',
            modalClass: 'CreateOrEditT_HClassModal'
        });

    



        _$t_HClasssTable.jtable({

            title: app.localize('T_HClass'),
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
                listAction: _t_HClassService.getPagedT_HClasssAsync
        
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
                                deleteT_HClass(data.record);
                            });
                    }
                    //添加
                    if (_permissions.create) {
                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("CreateT_HClass") + "' ><i class='fa fa-plus'></i></button>")
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

fK_ClassId: {
            title: app.localize('FK_ClassId'),
            width: '10%'
         },     
	  

fK_UserId: {
            title: app.localize('FK_UserId'),
            width: '10%'
         },     
	  

userName: {
            title: app.localize('UserName'),
            width: '10%'
         },     
	 
            }

        });

		
				   //打开添加窗口SPA
        $('#CreateNewT_HClassButton').click(function () {
            //可选生成的对话框大小{size:'lg'}or{size:'sm'}
            //需要到_createContainer方法中添加,_args.size
            _createOrEditModal.open();
        });
 



        //刷新表格信息
        $("#ButtonReload").click(function () {
            getT_HClasss();
        });




//模糊查询功能
function getT_HClasss(reload) {
    if (reload) {
        _$t_HClasssTable.jtable('reload');
    } else {
        _$t_HClasssTable.jtable('load', {
            filtertext: $('#T_HClasssTableFilter').val()
        });
    }
}
//
//删除当前t_HClass实体
function deleteT_HClass(t_HClass) {   
    abp.message.confirm(
        app.localize('T_HClassDeleteWarningMessage', t_HClass. fK_ClassId),
            function (isConfirmed) {
                if (isConfirmed) {
                    _t_HClassService.deleteT_HClassAsync({
                        id: t_HClass.id
                        }).done(function () {
                            getT_HClasss(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                }
            }
        );
}

 

//导出为excel文档
$('#ExportT_HClasssToExcelButton').click(function () {
    _t_HClassService
        .getT_HClasssToExcel({})
            .done(function (result) {
                app.downloadTempFile(result);
            });
});
//搜索
$('#GetT_HClasssButton').click(function (e) {
    e.preventDefault();
    getT_HClasss();
});

//制作T_HClass事件,用于请求变化后，刷新表格信息
abp.event.on('app.createOrEditT_HClassModalSaved', function () {
    getT_HClasss(true);
});

getT_HClasss();
 
 
    });
})();
