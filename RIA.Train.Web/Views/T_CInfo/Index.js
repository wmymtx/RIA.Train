


(function () {
    $(function () {

        var _$t_CInfosTable = $('#T_CInfosTable');
        var _t_CInfoService = abp.services.app.t_CInfo;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.T_CInfo.CreateT_CInfo"),
            edit: abp.auth.hasPermission("Pages.T_CInfo.EditT_CInfo"),
            'delete': abp.auth.hasPermission("Pages.T_CInfo.DeleteT_CInfo")

        };


      var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Mpa/T_CInfoManage/CreateOrEditT_CInfoModal',
            scriptUrl: abp.appPath + 'Areas/Mpa/Views/T_CInfoManage/_CreateOrEditT_CInfoModal.es5.min.js',
            modalClass: 'CreateOrEditT_CInfoModal'
        });

    



        _$t_CInfosTable.jtable({

            title: app.localize('T_CInfo'),
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
                listAction: {
                    method: _t_CInfoService.getPagedT_CInfosAsync
        }
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
                                deleteT_CInfo(data.record);
                            });
                    }
                    //添加
                    if (_permissions.create) {
                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("CreateT_CInfo") + "' ><i class='fa fa-plus'></i></button>")
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
	 
            }

        });

		
				   //打开添加窗口SPA
        $('#CreateNewT_CInfoButton').click(function () {
            //可选生成的对话框大小{size:'lg'}or{size:'sm'}
            //需要到_createContainer方法中添加,_args.size
            _createOrEditModal.open();
        });
 



        //刷新表格信息
        $("#ButtonReload").click(function () {
            getT_CInfos();
        });




//模糊查询功能
function getT_CInfos(reload) {
    if (reload) {
        _$t_CInfosTable.jtable('reload');
    } else {
        _$t_CInfosTable.jtable('load', {
            filtertext: $('#T_CInfosTableFilter').val()
        });
    }
}
//
//删除当前t_CInfo实体
function deleteT_CInfo(t_CInfo) {   
    abp.message.confirm(
        app.localize('T_CInfoDeleteWarningMessage', t_CInfo. fk_Id),
            function (isConfirmed) {
                if (isConfirmed) {
                    _t_CInfoService.deleteT_CInfoAsync({
                        id: t_CInfo.id
                        }).done(function () {
                            getT_CInfos(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                }
            }
        );
}

 

//导出为excel文档
$('#ExportT_CInfosToExcelButton').click(function () {
    _t_CInfoService
        .getT_CInfosToExcel({})
            .done(function (result) {
                app.downloadTempFile(result);
            });
});
//搜索
$('#GetT_CInfosButton').click(function (e) {
    e.preventDefault();
    getT_CInfos();
});

//制作T_CInfo事件,用于请求变化后，刷新表格信息
abp.event.on('app.createOrEditT_CInfoModalSaved', function () {
    getT_CInfos(true);
});

getT_CInfos();
 
 
    });
})();
