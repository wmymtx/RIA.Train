


(function () {
    $(function () {

        var _$t_ItemsTable = $('#T_ItemsTable');
        var _t_ItemService = abp.services.app.t_Item;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.T_Item.CreateT_Item"),
            edit: abp.auth.hasPermission("Pages.T_Item.EditT_Item"),
            'delete': abp.auth.hasPermission("Pages.T_Item.DeleteT_Item")

        };


      var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Mpa/T_ItemManage/CreateOrEditT_ItemModal',
            scriptUrl: abp.appPath + 'Areas/Mpa/Views/T_ItemManage/_CreateOrEditT_ItemModal.es5.min.js',
            modalClass: 'CreateOrEditT_ItemModal'
        });

    



        _$t_ItemsTable.jtable({

            title: app.localize('T_Item'),
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
                listAction: {
                    method: _t_ItemService.getPagedT_ItemsAsync
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
                                deleteT_Item(data.record);
                            });
                    }
                    //添加
                    if (_permissions.create) {
                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("CreateT_Item") + "' ><i class='fa fa-plus'></i></button>")
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

projectName: {
            title: app.localize('ProjectName'),
            width: '10%'
         },     
	  

createTime: {
            title: app.localize('CreateTime'),
            width: '10%'
         },     
	 
            }

        });

		
				   //打开添加窗口SPA
        $('#CreateNewT_ItemButton').click(function () {
            //可选生成的对话框大小{size:'lg'}or{size:'sm'}
            //需要到_createContainer方法中添加,_args.size
            _createOrEditModal.open();
        });
 



        //刷新表格信息
        $("#ButtonReload").click(function () {
            getT_Items();
        });




//模糊查询功能
function getT_Items(reload) {
    if (reload) {
        _$t_ItemsTable.jtable('reload');
    } else {
        _$t_ItemsTable.jtable('load', {
            filtertext: $('#T_ItemsTableFilter').val()
        });
    }
}
//
//删除当前t_Item实体
function deleteT_Item(t_Item) {   
    abp.message.confirm(
        app.localize('T_ItemDeleteWarningMessage', t_Item. projectName),
            function (isConfirmed) {
                if (isConfirmed) {
                    _t_ItemService.deleteT_ItemAsync({
                        id: t_Item.id
                        }).done(function () {
                            getT_Items(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                }
            }
        );
}

 

//导出为excel文档
$('#ExportT_ItemsToExcelButton').click(function () {
    _t_ItemService
        .getT_ItemsToExcel({})
            .done(function (result) {
                app.downloadTempFile(result);
            });
});
//搜索
$('#GetT_ItemsButton').click(function (e) {
    e.preventDefault();
    getT_Items();
});

//制作T_Item事件,用于请求变化后，刷新表格信息
abp.event.on('app.createOrEditT_ItemModalSaved', function () {
    getT_Items(true);
});

getT_Items();
 
 
    });
})();
