


(function () {
    $(function () {

        var _$t_KPointsTable = $('#T_KPointsTable');
        var _t_KPointService = abp.services.app.t_KPoint;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.T_KPoint.CreateT_KPoint"),
            edit: abp.auth.hasPermission("Pages.T_KPoint.EditT_KPoint"),
            'delete': abp.auth.hasPermission("Pages.T_KPoint.DeleteT_KPoint")

        };


      var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'T_KPoint/CreateOrEditT_KPointModal',
            scriptUrl: abp.appPath + 'Views/T_KPoint/_CreateOrEditT_KPointModal.js',
            modalClass: 'CreateOrEditT_KPointModal'
        });

    



        _$t_KPointsTable.jtable({

            title: app.localize('T_KPoint'),
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
                listAction: _t_KPointService.getPagedT_KPointsAsync
        
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
                   // }
                    //删除
                   // if (_permissions.delete) {
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('Delete') + '"><i class="fa fa-trash-o"></i></button>')
                            .appendTo($span)
                            .click(function () {
                                deleteT_KPoint(data.record);
                            });
                   // }
                    //添加
                  //  if (_permissions.create) {
                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("CreateT_KPoint") + "' ><i class='fa fa-plus'></i></button>")
                            .appendTo($span)
                            .click(function () {
							 _createOrEditModal.open();				                  

                            });
                  //  }

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
	  

trainContent: {
            title: app.localize('TrainContent'),
            width: '10%'
         },     
	 
            }

        });

		
				   //打开添加窗口SPA
        $('#CreateNewT_KPointButton').click(function () {
            //可选生成的对话框大小{size:'lg'}or{size:'sm'}
            //需要到_createContainer方法中添加,_args.size
            _createOrEditModal.open();
        });
 



        //刷新表格信息
        $("#ButtonReload").click(function () {
            getT_KPoints();
        });




//模糊查询功能
function getT_KPoints(reload) {
    if (reload) {
        _$t_KPointsTable.jtable('reload');
    } else {
        _$t_KPointsTable.jtable('load', {
            filtertext: $('#T_KPointsTableFilter').val()
        });
    }
}
//
//删除当前t_KPoint实体
function deleteT_KPoint(t_KPoint) {   
    abp.message.confirm(
        app.localize('T_KPointDeleteWarningMessage', t_KPoint. fk_Id),
            function (isConfirmed) {
                if (isConfirmed) {
                    _t_KPointService.deleteT_KPointAsync({
                        id: t_KPoint.id
                        }).done(function () {
                            getT_KPoints(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                }
            }
        );
}

 

//导出为excel文档
$('#ExportT_KPointsToExcelButton').click(function () {
    _t_KPointService
        .getT_KPointsToExcel({})
            .done(function (result) {
                app.downloadTempFile(result);
            });
});
//搜索
$('#GetT_KPointsButton').click(function (e) {
    e.preventDefault();
    getT_KPoints();
});

//制作T_KPoint事件,用于请求变化后，刷新表格信息
abp.event.on('app.createOrEditT_KPointModalSaved', function () {
    getT_KPoints(true);
});

getT_KPoints();
 
 
    });
})();
