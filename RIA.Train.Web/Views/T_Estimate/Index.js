


(function () {
    $(function () {

        var _$t_StaffsTable = $('#T_StaffsTable');
        var _t_StaffService = abp.services.app.t_Staff;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.T_Staff.CreateT_Staff"),
            edit: abp.auth.hasPermission("Pages.T_Staff.EditT_Staff"),
            'delete': abp.auth.hasPermission("Pages.T_Staff.DeleteT_Staff")

        };


      var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'T_Staff/CreateOrEditT_StaffModal',
            scriptUrl: 'Views/T_Staff/_CreateOrEditT_StaffModal.js',
            modalClass: 'CreateOrEditT_StaffModal'
        });

    



        _$t_StaffsTable.jtable({

            title: app.localize('T_Staff'),
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
                listAction:  _t_StaffService.getPagedT_StaffsAsync
        
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
                                deleteT_Staff(data.record);
                            });
                    }
                    //添加
                    if (_permissions.create) {
                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("CreateT_Staff") + "' ><i class='fa fa-plus'></i></button>")
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

fK_GroupId: {
            title: app.localize('FK_GroupId'),
            width: '10%'
         },     
	  

staffName: {
            title: app.localize('StaffName'),
            width: '10%'
         },     
	  

creteTime: {
            title: app.localize('CreteTime'),
            width: '10%'
         },     
	 
            }

        });

		
				   //打开添加窗口SPA
        $('#CreateNewT_StaffButton').click(function () {
            //可选生成的对话框大小{size:'lg'}or{size:'sm'}
            //需要到_createContainer方法中添加,_args.size
            _createOrEditModal.open();
        });
 



        //刷新表格信息
        $("#ButtonReload").click(function () {
            getT_Staffs();
        });




//模糊查询功能
function getT_Staffs(reload) {
    if (reload) {
        _$t_StaffsTable.jtable('reload');
    } else {
        _$t_StaffsTable.jtable('load', {
            filtertext: $('#T_StaffsTableFilter').val()
        });
    }
}
//
//删除当前t_Staff实体
function deleteT_Staff(t_Staff) {   
    abp.message.confirm(
        app.localize('T_StaffDeleteWarningMessage', t_Staff. fK_GroupId),
            function (isConfirmed) {
                if (isConfirmed) {
                    _t_StaffService.deleteT_StaffAsync({
                        id: t_Staff.id
                        }).done(function () {
                            getT_Staffs(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                }
            }
        );
}

 

//导出为excel文档
$('#ExportT_StaffsToExcelButton').click(function () {
    _t_StaffService
        .getT_StaffsToExcel({})
            .done(function (result) {
                app.downloadTempFile(result);
            });
});
//搜索
$('#GetT_StaffsButton').click(function (e) {
    e.preventDefault();
    getT_Staffs();
});

//制作T_Staff事件,用于请求变化后，刷新表格信息
abp.event.on('app.createOrEditT_StaffModalSaved', function () {
    getT_Staffs(true);
});

getT_Staffs();
 
 
    });
})();
