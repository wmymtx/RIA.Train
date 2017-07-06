


(function () {
    $(function () {
        var $jstree = $('#jsTree');
        var _$t_StaffsTable = $('#T_StaffsTable');
        var _t_StaffService = abp.services.app.t_Staff;
        var _t_GroupService = abp.services.app.t_Group;

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

      var FK_Staff_GroupId;

    

      function initJsTree(data) {
          $jstree.jstree({
              core: {
                  check_callback: true,
                  data: data,
              },
              plugins: ["wholerow", "contextmenu"],
              "contextmenu": {
                  "items": {
                      "create": null,
                      "rename": null,
                      "remove": null,
                      "ccp": null,
                      "add": {
                          "label": "新增人员",
                          "action": function (obj) {
                              var inst = jQuery.jstree.reference(obj.reference);
                              var clickedNode = inst.get_node(obj.reference);
                              _createOrEditModal.open({ id: 100000 + clickedNode.id });
                              //alert("add operation--clickedNode's id is:" + clickedNode.id);
                          }
                      }
                     
                  }
              }
          }).on("ready.jstree", function (e, data) {
              data.instance.open_all();
              }).on('changed.jstree', function (e, data) {
                  r = [];
                  var i, j;
                  for (i = 0, j = data.selected.length; i < j; i++) {
                      var node = data.instance.get_node(data.selected[i]);
                      if (data.instance.is_leaf(node)) {
                          r.push(node.id);
                          FK_Staff_GroupId = node.id;
                      }
                  }
                  getT_Staffs();
                  //alert('Selected: ' + r.join('@@'));  
              }) ;
      }



      function Refresh() {
          
          console.log(_t_GroupService.getPagedT_GroupsAsync);
          abp.ajax({
              url: abp.appPath + 'api/services/app/t_Group/GetPagedT_GroupsAsync',
              data: JSON.stringify({})
          }).done(function (data) {
              var treeData = []
              var items = data.records;
              for (var index = 0; index <= items.length - 1; index++) {
                  treeData.push({ "id": items[index].id, "parent": items[index].parentId == 0 ? "#" : items[index].parentId, "text": items[index].groupName });
              }
              var exData = [
                  { "id": "1", "parent": "#", "text": "root" },
                  { "id": "2", "parent": "1", "text": "child 1" },
                  { "id": "3", "parent": "1", "text": "child 2" }
              ];
              initJsTree(treeData);

              abp.notify.success('created new person with id = ' + data.personId);
          });
      }
      Refresh();


        _$t_StaffsTable.jtable({

            title: '人员信息',
            paging: true,
            sorting: true,
            multiSorting: true,
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
                    
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('Edit') + '"><i class="fa fa-edit"></i></button>')
                            .appendTo($span)
                            .click(function () {
 _createOrEditModal.open({ id: data.record.id });                            });
                   
                    //删除
                  
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('Delete') + '"><i class="fa fa-trash-o"></i></button>')
                            .appendTo($span)
                            .click(function () {
                                deleteT_Staff(data.record);
                            });
                 
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

           


            staffName: {
                title: '姓名',
                width: '10%'
            },


            loginNo: {
                title: '工资号',
                width: '10%'
            },


            passWord: {
                title: '密码',
                width: '10%'
            },


            openId: {
                title: '微信openId',
                width: '10%'
            },


            creteTime: {
                title: '创建时间',
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
            FK_Staff_GroupId = 0;
            getT_Staffs();
        });




//模糊查询功能
function getT_Staffs(reload) {
    if (reload) {
        _$t_StaffsTable.jtable('reload');
    } else {
        _$t_StaffsTable.jtable('load', {
            filtertext: $('#T_StaffsTableFilter').val(),
            FK_Staff_GroupId: FK_Staff_GroupId
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
