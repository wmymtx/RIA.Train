


(function () {
    $(function () {

        var _$t_GradesTable = $('#T_GradesTable');
        var _t_GradeService = abp.services.app.t_Grade;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.T_Grade.CreateT_Grade"),
            edit: abp.auth.hasPermission("Pages.T_Grade.EditT_Grade"),
            'delete': abp.auth.hasPermission("Pages.T_Grade.DeleteT_Grade")

        };


      var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'T_Grade/CreateOrEditT_GradeModal',
            scriptUrl: abp.appPath + 'Views/T_Grade/_CreateOrEditT_GradeModal.js',
            modalClass: 'CreateOrEditT_GradeModal'
        });

    



        _$t_GradesTable.jtable({

            title: app.localize('T_Grade'),
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
                listAction: _t_GradeService.getPagedT_GradesAsync
        
            },

        fields: {
           
            actions: {
                title: app.localize('Actions'),
                width: '10%',
                sorting: false,
                display: function (data) {
                    var $span = $('<span></span>');
                    //编辑
                   // if (_permissions.edit) {
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('Edit') + '"><i class="fa fa-edit"></i></button>')
                            .appendTo($span)
                            .click(function () {
 _createOrEditModal.open({ id: data.record.id });                            });
                 //   }
                    //删除
                   // if (_permissions.delete) {
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('Delete') + '"><i class="fa fa-trash-o"></i></button>')
                            .appendTo($span)
                            .click(function () {
                                deleteT_Grade(data.record);
                            });
                  //  }
                    //添加
                   // if (_permissions.create) {
                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("CreateT_Grade") + "' ><i class='fa fa-plus'></i></button>")
                            .appendTo($span)
                            .click(function () {
							 _createOrEditModal.open();				                  

                            });
                   // }

                    return $span;
            }
        },
		//此处开始循环数据

	 

          id: {           
                 key: true,
                list: false
         }, 	  

grade: {
            title: app.localize('Grade'),
            width: '10%'
         },     
	 
            }

        });

		
				   //打开添加窗口SPA
        $('#CreateNewT_GradeButton').click(function () {
            //可选生成的对话框大小{size:'lg'}or{size:'sm'}
            //需要到_createContainer方法中添加,_args.size
            _createOrEditModal.open();
        });
 



        //刷新表格信息
        $("#ButtonReload").click(function () {
            getT_Grades();
        });




//模糊查询功能
function getT_Grades(reload) {
    if (reload) {
        _$t_GradesTable.jtable('reload');
    } else {
        _$t_GradesTable.jtable('load', {
            filtertext: $('#T_GradesTableFilter').val()
        });
    }
}
//
//删除当前t_Grade实体
function deleteT_Grade(t_Grade) {   
    abp.message.confirm(
        app.localize('T_GradeDeleteWarningMessage', t_Grade. grade),
            function (isConfirmed) {
                if (isConfirmed) {
                    _t_GradeService.deleteT_GradeAsync({
                        id: t_Grade.id
                        }).done(function () {
                            getT_Grades(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                }
            }
        );
}

 

//导出为excel文档
$('#ExportT_GradesToExcelButton').click(function () {
    _t_GradeService
        .getT_GradesToExcel({})
            .done(function (result) {
                app.downloadTempFile(result);
            });
});
//搜索
$('#GetT_GradesButton').click(function (e) {
    e.preventDefault();
    getT_Grades();
});

//制作T_Grade事件,用于请求变化后，刷新表格信息
abp.event.on('app.createOrEditT_GradeModalSaved', function () {
    getT_Grades(true);
});

getT_Grades();
 
 
    });
})();
