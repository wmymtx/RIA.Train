


(function () {
    $(function () {

        var _$t_ContentsTable = $('#T_ContentsTable');
        var _t_ContentService = abp.services.app.t_Content;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.T_Content.CreateT_Content"),
            edit: abp.auth.hasPermission("Pages.T_Content.EditT_Content"),
            'delete': abp.auth.hasPermission("Pages.T_Content.DeleteT_Content")

        };


      var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'T_Content/CreateOrEditT_ContentModal',
            scriptUrl:  'Views/T_Content/_CreateOrEditT_ContentModal.js',
            modalClass: 'CreateOrEditT_ContentModal'
        });

    



        _$t_ContentsTable.jtable({

            title: app.localize('T_Content'),
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
                listAction:  _t_ContentService.getPagedT_ContentsAsync
        
            },

        fields: {
           
            actions: {
                title: app.localize('Actions'),
                width: '10%',
                sorting: false,
                display: function (data) {
                    var $span = $('<span></span>');
                    //编辑
                    //if (_permissions.edit) {
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('Edit') + '"><i class="fa fa-edit"></i></button>')
                            .appendTo($span)
                            .click(function () {
 _createOrEditModal.open({ id: data.record.id });                            });
                    //}
                    //删除
                    //if (_permissions.delete) {
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('Delete') + '"><i class="fa fa-trash-o"></i></button>')
                            .appendTo($span)
                            .click(function () {
                                deleteT_Content(data.record);
                            });
                    //}
                    //添加
                   // if (_permissions.create) {
                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("CreateT_Content") + "' ><i class='fa fa-plus'></i></button>")
                            .appendTo($span)
                            .click(function () {
							 _createOrEditModal.open();				                  

                            });
                    //}

                    return $span;
            }
        },
		//此处开始循环数据

	 

          id: {           
                 key: true,
                list: false
         }, 	  

content: {
            title: app.localize('Content'),
            width: '10%'
         },     
	 
            }

        });

		
				   //打开添加窗口SPA
        $('#CreateNewT_ContentButton').click(function () {
            //可选生成的对话框大小{size:'lg'}or{size:'sm'}
            //需要到_createContainer方法中添加,_args.size
            _createOrEditModal.open();
        });
 



        //刷新表格信息
        $("#ButtonReload").click(function () {
            getT_Contents();
        });




//模糊查询功能
function getT_Contents(reload) {
    if (reload) {
        _$t_ContentsTable.jtable('reload');
    } else {
        _$t_ContentsTable.jtable('load', {
            filtertext: $('#T_ContentsTableFilter').val()
        });
    }
}
//
//删除当前t_Content实体
function deleteT_Content(t_Content) {   
    abp.message.confirm(
        app.localize('T_ContentDeleteWarningMessage', t_Content. content),
            function (isConfirmed) {
                if (isConfirmed) {
                    _t_ContentService.deleteT_ContentAsync({
                        id: t_Content.id
                        }).done(function () {
                            getT_Contents(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                }
            }
        );
}

 

//导出为excel文档
$('#ExportT_ContentsToExcelButton').click(function () {
    _t_ContentService
        .getT_ContentsToExcel({})
            .done(function (result) {
                app.downloadTempFile(result);
            });
});
//搜索
$('#GetT_ContentsButton').click(function (e) {
    e.preventDefault();
    getT_Contents();
});

//制作T_Content事件,用于请求变化后，刷新表格信息
abp.event.on('app.createOrEditT_ContentModalSaved', function () {
    getT_Contents(true);
});

getT_Contents();
 
 
    });
})();
