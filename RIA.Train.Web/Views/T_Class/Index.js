


(function () {
    $(function () {

        var _$t_ClasssTable = $('#T_ClasssTable');
        var _t_ClassService = abp.services.app.t_Class;
        var _t_EstimateService = abp.services.app.t_Estimate;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.T_Class.CreateT_Class"),
            edit: abp.auth.hasPermission("Pages.T_Class.EditT_Class"),
            'delete': abp.auth.hasPermission("Pages.T_Class.DeleteT_Class")

        };
        var _createOrEditT_StaffModal = null;

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'T_Class/CreateOrEditT_ClassModal',
            scriptUrl: 'Views/T_Class/_CreateOrEditT_ClassModal.js',
            modalClass: 'CreateOrEditT_ClassModal'
        });

        var _createOrEditT_CInfoModal = new app.ModalManager({
            viewUrl: abp.appPath + 'T_Class/ShowT_HClassModal',
            scriptUrl: abp.appPath + 'Views/T_Class/ShowT_HClassModal.js',
            modalClass: 'ShowT_HClassModal'
        });
        //var _createOrEditT_StaffModal = new app.ModalManager({
        //    viewUrl: abp.appPath + 'T_Class/SelectStaff_ClassModal',
        //    scriptUrl: abp.appPath + 'Views/T_Class/SelectStaff_ClassModal.js',
        //    modalClass: 'SelectStaff_ClassModal'
        //});




        _$t_ClasssTable.jtable({

            title: '培训信息配置表',
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
                listAction: _t_ClassService.getPagedT_ClasssAsync

            },

            fields: {

                actions: {
                    title: '操作',
                    width: '10%',
                    sorting: false,
                    display: function (data) {
                        var $span = $('<span></span>');
                        //编辑

                        $('<button class="btn btn-default btn-xs" title="' + app.localize('编辑') + '"><i class="fa fa-edit"></i></button>')
                            .appendTo($span)
                            .click(function () {
                                _createOrEditModal.open({ id: data.record.id });
                            });
                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("选择参培人员") + "' ><i class='fa fa-plus'></i></button>")
                            .appendTo($span)
                            .click(function () {
                                _createOrEditT_StaffModal = new app.ModalManager({
                                    viewUrl: abp.appPath + 'T_Class/SelectStaff_ClassModal',
                                    scriptUrl: abp.appPath + 'Views/T_Class/SelectStaff_ClassModal.js',
                                    modalClass: 'SelectStaff_ClassModal'
                                });
                                _createOrEditT_StaffModal.open({ id: data.record.id });
                                _createOrEditT_StaffModal.onClose(function () {
                                    window.location = window.location;
                                });
                            });
                        //删除

                        $('<button class="btn btn-default btn-xs" title="' + app.localize('删除') + '"><i class="fa fa-trash-o"></i></button>')
                            .appendTo($span)
                            .click(function () {
                                deleteT_Class({ id: data.record.id });
                            });

                        //添加



                        $("<button id='" + data.record.id + "' class='btn btn-default copy btn-xs'  title='" + app.localize("发布评价") + "' ><i class='glyphicon  glyphicon-share'></i></button>")
                            .appendTo($span);


                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("查看人员") + "' ><i class='fa fa-compress'></i></button>")
                            .appendTo($span)
                            .click(function () {
                                // _createOrEditModal.open();
                                _createOrEditT_CInfoModal.open({ id: data.record.id });
                                _createOrEditT_CInfoModal.onClose(function () {
                                    window.location = window.location;
                                });

                            });

                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("下载评价内容") + "' ><i class='glyphicon glyphicon-download-alt'></i></button>")
                            .appendTo($span)
                            .click(function () {
                                // _createOrEditModal.open();
                                //_createOrEditClassModal.open({ id: "100000" + data.record.id })
                                _t_EstimateService
                                    .getT_EstimateToExcel({ FK_ClassId: data.record.id })
                                    .done(function (result) {
                                        app.downloadTempFile(result);
                                    });

                            });




                        return $span;
                    }
                },
                //此处开始循环数据



                id: {
                    key: true,
                    list: false
                },

                Phones: {
                    title: '展开评价汇总',
                    width: '5%',
                    sorting: false,
                    edit: false,
                    create: false,
                    listClass: 'child-opener-image-column',
                    display: function (itemData) {
                        //Create an image that will be used to open child table
                        var $img = $('<img class="child-opener-image" src="/Content/images/Misc/note.png" title="Edit exam results" />');
                        //Open child table when user clicks the image
                        $img.click(function () {
                            _$t_ClasssTable.jtable('openChildTable',
                                $img.closest('tr'), //Parent row
                                {
                                    title: '评价信息',
                                    actions: {
                                        listAction: _t_EstimateService.getPagedT_EstimatesAsync

                                    },
                                    fields: {

                                        id: {
                                            key: true,
                                            create: true,
                                            edit: false,
                                            list: false
                                        },

                                        vContent: {
                                            title: '评价内容',
                                            width: '10%'
                                        },
                                        vGrade: {
                                            title: '评价等级',
                                            width: '10%'
                                        },
                                        contentCount: {
                                            title: '评价次数',
                                            width: '10%'
                                        },

                                    }
                                }, function (data) { //opened handler
                                    data.childTable.jtable('load', { FK_ClassId: itemData.record.id });
                                });
                        });
                        //Return image to show on the person row
                        return $img;
                    }
                },


                trainingTime: {
                    title: '培训时间',
                    width: '10%'
                },


                trainingPlace: {
                    title: '培训地点',
                    width: '10%'
                },

                projectName: {
                    title: '培训项目',
                    width: '10%'
                },
                trainintTeacher: {
                    title: '培训老师',
                    width: '10%'
                }





            }, recordsLoaded: function (e, data) {
                var clipboard = new Clipboard('.copy', {
                    text: function (trigger) {
                        abp.notify.success("该地址已经复制，你可以使用Ctrl+V 粘贴。");
                        //alert($(this).attr('id'));
                        return window.location.protocol + "//" + window.location.host + '/WeChatEstimate/Index?id=' + trigger.getAttribute('id');
                    }
                });


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
                app.localize('T_ClassDeleteWarningMessage'),
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
        $('#ButtonDownLoad').click(function () {
            _t_EstimateService
                .getT_EstimateToExcel({ FK_ClassId: 0 })
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
