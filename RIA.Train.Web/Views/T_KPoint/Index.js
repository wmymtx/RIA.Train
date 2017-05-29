


(function () {
    $(function () {

        var _$t_ClasssTable = $('#T_ClasssTable');
        var _t_ClassService = abp.services.app.t_Class;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.T_Class.CreateT_Class"),
            edit: abp.auth.hasPermission("Pages.T_Class.EditT_Class"),
            'delete': abp.auth.hasPermission("Pages.T_Class.DeleteT_Class")

        };


      var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Mpa/T_ClassManage/CreateOrEditT_ClassModal',
            scriptUrl: abp.appPath + 'Areas/Mpa/Views/T_ClassManage/_CreateOrEditT_ClassModal.es5.min.js',
            modalClass: 'CreateOrEditT_ClassModal'
        });

    



        _$t_ClasssTable.jtable({

            title: app.localize('T_Class'),
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
                listAction: {
                    method: _t_ClassService.getPagedT_ClasssAsync
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
                                deleteT_Class(data.record);
                            });
                    }
                    //添加
                    if (_permissions.create) {
                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("CreateT_Class") + "' ><i class='fa fa-plus'></i></button>")
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
	  

trainingTime: {
            title: app.localize('TrainingTime'),
            width: '10%'
         },     
	  

trainingPlace: {
            title: app.localize('TrainingPlace'),
            width: '10%'
         },     
	  

trainintTeacher: {
            title: app.localize('TrainintTeacher'),
            width: '10%'
         },     
	  

createTime: {
            title: app.localize('CreateTime'),
            width: '10%'
         },     
	 
            }

        });

		
				   //打开添加窗口SPA
        $('#CreateNewT_ClassButton').click(function () {
            //可选生成的对话框大小{size:'lg'}or{size:'sm'}
            //需要到_createContainer方法中添加,_args.size
            _createOrEditModal.open();
        });
 



        //刷新表格信息
        $("#ButtonReload").click(function () {
            getT_Classs();
        });




//模糊查询功能
function getT_Classs(reload) {
    if (reload) {
        _$t_ClasssTable.jtable('reload');
    } else {
        _$t_ClasssTable.jtable('load', {
            filtertext: $('#T_ClasssTableFilter').val()
        });
    }
}
//
//删除当前t_Class实体
function deleteT_Class(t_Class) {   
    abp.message.confirm(
        app.localize('T_ClassDeleteWarningMessage', t_Class. fk_Id),
            function (isConfirmed) {
                if (isConfirmed) {
                    _t_ClassService.deleteT_ClassAsync({
                        id: t_Class.id
                        }).done(function () {
                            getT_Classs(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                }
            }
        );
}

 

//导出为excel文档
$('#ExportT_ClasssToExcelButton').click(function () {
    _t_ClassService
        .getT_ClasssToExcel({})
            .done(function (result) {
                app.downloadTempFile(result);
            });
});
//搜索
$('#GetT_ClasssButton').click(function (e) {
    e.preventDefault();
    getT_Classs();
});

//制作T_Class事件,用于请求变化后，刷新表格信息
abp.event.on('app.createOrEditT_ClassModalSaved', function () {
    getT_Classs(true);
});

getT_Classs();
 
 
    });
})();
