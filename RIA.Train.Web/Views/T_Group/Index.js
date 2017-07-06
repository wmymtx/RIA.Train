﻿


(function () {
    $(function () {

        var _$t_GroupsTable = $('#T_GroupsTable');
        var _t_GroupService = abp.services.app.t_Group;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.T_Group.CreateT_Group"),
            edit: abp.auth.hasPermission("Pages.T_Group.EditT_Group"),
            'delete': abp.auth.hasPermission("Pages.T_Group.DeleteT_Group")

        };


      var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'T_Group/CreateOrEditT_GroupModal',
            scriptUrl:  'Views/T_Group/_CreateOrEditT_GroupModal.js',
            modalClass: 'CreateOrEditT_GroupModal'
        });

    



        _$t_GroupsTable.jtable({

            title: app.localize('T_Group'),
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
                listAction: _t_GroupService.getPagedT_GroupsAsync
        
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
                    //if (_permissions.delete) {
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('Delete') + '"><i class="fa fa-trash-o"></i></button>')
                            .appendTo($span)
                            .click(function () {
                                deleteT_Group(data.record);
                            });
                   // }
                    //添加
                    if (_permissions.create) {
                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("CreateT_Group") + "' ><i class='fa fa-plus'></i></button>")
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

groupName: {
            title: app.localize('GroupName'),
            width: '10%'
         },     
	  

parentId: {
            title: app.localize('ParentId'),
            width: '10%'
         },     
	 
            }

        });

		
				   //打开添加窗口SPA
        $('#CreateNewT_GroupButton').click(function () {
            //可选生成的对话框大小{size:'lg'}or{size:'sm'}
            //需要到_createContainer方法中添加,_args.size
            _createOrEditModal.open();
        });
 



        //刷新表格信息
        $("#ButtonReload").click(function () {
            getT_Groups();
        });




//模糊查询功能
function getT_Groups(reload) {
    if (reload) {
        _$t_GroupsTable.jtable('reload');
    } else {
        _$t_GroupsTable.jtable('load', {
            filtertext: $('#T_GroupsTableFilter').val()
        });
    }
}
//
//删除当前t_Group实体
function deleteT_Group(t_Group) {   
    abp.message.confirm(
        app.localize('T_GroupDeleteWarningMessage', t_Group. groupName),
            function (isConfirmed) {
                if (isConfirmed) {
                    _t_GroupService.deleteT_GroupAsync({
                        id: t_Group.id
                        }).done(function () {
                            getT_Groups(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                }
            }
        );
}

 

//导出为excel文档
$('#ExportT_GroupsToExcelButton').click(function () {
    _t_GroupService
        .getT_GroupsToExcel({})
            .done(function (result) {
                app.downloadTempFile(result);
            });
});
//搜索
$('#GetT_GroupsButton').click(function (e) {
    e.preventDefault();
    getT_Groups();
});

//制作T_Group事件,用于请求变化后，刷新表格信息
abp.event.on('app.createOrEditT_GroupModalSaved', function () {
    getT_Groups(true);
});

getT_Groups();
 
 
    });
})();
