
var selectRow = [];

(function () {
    $(function () {
        var $jstree = $('#jsTree');
        var fk_Id = $('#fk_Id').val();
        var _$t_StaffsTable = $('#T_StaffsTable');
        var _t_StaffService = abp.services.app.t_Staff;
        var _t_GroupService = abp.services.app.t_Group;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.T_Staff.CreateT_Staff"),
            edit: abp.auth.hasPermission("Pages.T_Staff.EditT_Staff"),
            'delete': abp.auth.hasPermission("Pages.T_Staff.DeleteT_Staff")

        };



        var FK_Staff_GroupId = 0;



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
            });
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

            title: app.localize('T_Staff'),
            paging: true,
            sorting: true,
            selecting: true, //Enable selecting
            multiselect: true, //Allow multiple selecting
            selectingCheckboxes: true, //Show checkboxes on first column
            //  multiSorting: true,
            actions: {
                listAction: _t_StaffService.getPagedT_StaffsAsync

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
                                    _createOrEditModal.open({ id: data.record.id });
                                });
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


                staffName: {
                    title: '姓名',
                    width: '10%'
                },


                loginNo: {
                    title: '工资号',
                    width: '10%'
                },




            }, selectionChanged: function () {
                //Get all selected rows
                var $selectedRows = _$t_StaffsTable.jtable('selectedRows');
                selectRow = [];
                $('#SelectedRowList').empty();
                if ($selectedRows.length > 0) {
                    
                    //Show selected rows
                    $selectedRows.each(function () {
                        var record = $(this).data('record');
                        selectRow.push({ Fk_Item_CInfo_Id: fk_Id, Fk_CInfo_UserId: record.id, UserName: record.staffName });
                        $('#SelectedRowList').append(

                            '<b>参与人</b>:' + record.staffName + '<br />'
                        );
                    });
                } else {
                    //No rows selected
                    $('#SelectedRowList').append('No row selected! Select rows to see here...');
                }
            }

        });
        var selectRow = [];

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
                    filtertext: $('#T_StaffsTableFilter').val(),
                    FK_Staff_GroupId: FK_Staff_GroupId
                });
            }
        }
        //
        //删除当前t_Staff实体
        function deleteT_Staff(t_Staff) {
            abp.message.confirm(
                app.localize('T_StaffDeleteWarningMessage', t_Staff.fK_GroupId),
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

        app.modals.SelectStaffModal = function () {

            var _modalManager;

            var _t_StaffService = abp.services.app.t_CInfo;

            $(".maxlength-handler").maxlength({
                limitReachedClass: "label label-danger",
                alwaysShow: true,
                threshold: 5,
                placement: 'bottom'
            });

            var _$t_StaffInformationForm = null;


            this.init = function (modalManager) {
                _modalManager = modalManager;
                _$t_StaffInformationForm = _modalManager.getModal().find("form[name=t_StaffInformationsForm]");

































                // 初始化 CreteTime 的包含时分秒的日期控件
                //包含时分秒的日期选择器             
                //        $("input[name=CreteTime]").datetimepicker({
                //            autoclose: true,
                //            isRTL: false,
                //            format: "yyyy-mm-dd hh:ii",
                //            pickerPosition: ("bottom-left"),
                ////默认为E文按钮要中文，自己去找语言包
                //   todayBtn: true,
                //     language: "zh-CN"
                //        });








            }

            this.save = function () {
                if (!_$t_StaffInformationForm.valid()) {
                    return;
                }
                //校验通过

                var t_Staff = _$t_StaffInformationForm.serializeFormToObject();
                //  console.log(t_Staff);

                _modalManager.setBusy(true);
                console.log(selectRow);
                _t_StaffService.batchCreateOrUpdateT_CInfoAsync({
                    t_CInfoEditDto: selectRow
                }).done(function () {
                    //提示信息
                    abp.notify.info(app.localize('SavedSuccessfully'));
                    //关闭窗体
                    _modalManager.close();
                    //信息保存成功后调用事件，刷新列表
                    abp.event.trigger('app.createOrEditT_StaffModalSaved');
                }).always(function () {
                    _modalManager.setBusy(false);
                });
            }
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

app = app || {};
app.modals = app.modals || {};
(function ($) {

})(jQuery);


