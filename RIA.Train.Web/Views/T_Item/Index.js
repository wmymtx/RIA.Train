


(function () {
    $(function () {

        var _$t_ItemsTable = $('#T_ItemsTable');
        var _t_ItemService = abp.services.app.t_Item;
        var _t_KPointService = abp.services.app.t_KPoint;
        var _t_RequireService = abp.services.app.t_Require;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.T_Item.CreateT_Item"),
            edit: abp.auth.hasPermission("Pages.T_Item.EditT_Item"),
            'delete': abp.auth.hasPermission("Pages.T_Item.DeleteT_Item")

        };


        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'T_Item/CreateOrEditT_ItemModal',
            scriptUrl: 'Views/T_Item/_CreateOrEditT_ItemModal.js',
            modalClass: 'CreateOrEditT_ItemModal'
        });


        var _createOrEditT_KPointModal = new app.ModalManager({
            viewUrl: abp.appPath + 'T_KPoint/CreateOrEditT_KPointModal',
            scriptUrl: abp.appPath + 'Views/T_KPoint/_CreateOrEditT_KPointModal.js',
            modalClass: 'CreateOrEditT_KPointModal'
        });

        var _createOrEditT_StaffModal = new app.ModalManager({
            viewUrl: abp.appPath + 'T_Staff/SelectStaffModal',
            scriptUrl: abp.appPath + 'Views/T_Staff/SelectStaffModal.js',
            modalClass: 'SelectStaffModal'
        });



        var _createOrEditClassModal = new app.ModalManager({
            viewUrl: abp.appPath + 'T_Class/CreateOrEditT_ClassModal',
            scriptUrl: 'Views/T_Class/_CreateOrEditT_ClassModal.js',
            modalClass: 'CreateOrEditT_ClassModal'
        });



        _$t_ItemsTable.jtable({

            title: '培训项目',
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
                listAction: _t_ItemService.getPagedT_ItemsAsync

            },

            fields: {

                actions: {
                    title: '操作',
                    width: '10%',
                    sorting: false,
                    display: function (data) {
                        var $span = $('<span></span>');
                        //编辑
                        //if (_permissions.edit) {
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('编辑') + '"><i class="fa fa-edit"></i></button>')
                            .appendTo($span)
                            .click(function () {
                                _createOrEditModal.open({ id: data.record.id });
                            });
                        // }
                        //删除
                        //  if (_permissions.delete) {
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('删除') + '"><i class="fa fa-trash-o"></i></button>')
                            .appendTo($span)
                            .click(function () {
                                deleteT_Item(data.record);
                            });
                        // }
                        //添加
                        // if (_permissions.create) {
                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("添加重点") + "' ><i class='fa fa-plus'></i></button>")
                            .appendTo($span)
                            .click(function () {
                                // _createOrEditModal.open();
                                _createOrEditT_KPointModal.open({ id: "100000" + data.record.id });

                            });

                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("添加人员") + "' ><i class='fa fa-compress'></i></button>")
                            .appendTo($span)
                            .click(function () {
                                // _createOrEditModal.open();
                                _createOrEditT_StaffModal.open({ id: data.record.id });
                                _createOrEditT_StaffModal.onClose(function () {
                                    window.location = window.location;
                                });


                            });
                        $("<button  class='btn btn-default  btn-xs'  title='" + app.localize("查看参培人员") + "' ><i class='fa fa-play-circle-o'></i></button>")
                            .appendTo($span)
                            .click(function () {
                                var _createOrEditT_CInfoModal = new app.ModalManager({
                                    viewUrl: abp.appPath + 'T_Item/ShowT_ItemModal',
                                    scriptUrl: abp.appPath + 'Views/T_Item/ShowT_ItemModal.js',
                                    modalClass: 'ShowT_ItemModal'
                                });
                                // _createOrEditModal.open();
                                _createOrEditT_CInfoModal.open({ id: data.record.id });
                                _createOrEditT_CInfoModal.onClose(function () {
                                    // _createOrEditT_CInfoModal.removeContainer();
                                    //abp.event.trigger('app.createOrEditT_ItemModalSaved');
                                    //getT_Items(true);
                                    window.location = window.location;
                                });

                            });

                        $("<button id=" + data.record.id + " class='btn copy btn-default  btn-xs'  title='" + app.localize("复制需求提报URL地址") + "' ><i class='glyphicon  glyphicon-share'></i></button>")
                            .appendTo($span);
                        //.click(function () {
                        //    // _createOrEditModal.open();
                        //    var clipBoardContent = location;
                        //    //copyToClipboard(clipBoardContent);
                        //    //window.clipboardData.setData("Text", clipBoardContent);


                        //});

                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("发布课程") + "' ><i class='glyphicon glyphicon-pencil'></i></button>")
                            .appendTo($span)
                            .click(function () {
                                // _createOrEditModal.open();
                                _createOrEditClassModal.open({ id: "100000" + data.record.id })

                            });

                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("下载需求提报") + "' ><i class='glyphicon glyphicon-download-alt'></i></button>")
                            .appendTo($span)
                            .click(function () {
                                // _createOrEditModal.open();
                                //_createOrEditClassModal.open({ id: "100000" + data.record.id })
                                _t_RequireService
                                    .getT_RequireToExcel({ Fk_Item_Require_Id: data.record.id })
                                    .done(function (result) {
                                        app.downloadTempFile(result);
                                    });

                            });


                        //}

                        return $span;
                    }
                },
                //此处开始循环数据



                id: {
                    key: true,
                    create: false,
                    edit: false,
                    list: false
                },
                Exams: {
                    title: '展开重点内容',
                    width: '4%',
                    sorting: false,
                    edit: false,
                    create: false,
                    listClass: 'child-opener-image-column',
                    display: function (itemData) {
                        //Create an image that will be used to open child table
                        var $img = $('<img class="child-opener-image" src="/Content/images/Misc/note.png" title="Edit exam results" />');
                        //Open child table when user clicks the image
                        $img.click(function () {
                            $('#T_ItemsTable').jtable('openChildTable',
                                $img.closest('tr'), //Parent row
                                {
                                    title: itemData.record.projectName,
                                    actions: {
                                        listAction: _t_KPointService.getPagedT_KPointsByItemIdAsync

                                    },
                                    fields: {

                                        id: {
                                            key: true,
                                            create: true,
                                            edit: false,
                                            list: false
                                        },
                                        actions: {
                                            title: '子项操作',
                                            width: '10%',
                                            sorting: false,
                                            display: function (data) {
                                                var $span = $('<span></span>');
                                                //编辑
                                                //if (_permissions.edit) {
                                                $('<button class="btn btn-default btn-xs" title="' + app.localize('编辑') + '"><i class="fa fa-edit"></i></button>')
                                                    .appendTo($span)
                                                    .click(function () {
                                                        _createOrEditT_KPointModal.open({ id: data.record.id });
                                                    });
                                                // }
                                                //删除
                                                //  if (_permissions.delete) {
                                                $('<button class="btn btn-default btn-xs" title="' + app.localize('删除') + '"><i class="fa fa-trash-o"></i></button>')
                                                    .appendTo($span)
                                                    .click(function () {
                                                        deleteT_KPoint(data.record);
                                                    });
                                                // }
                                                //添加
                                                // if (_permissions.create) {

                                                //}

                                                return $span;
                                            }
                                        },
                                        trainContent: {
                                            title: '重点内容',
                                            width: '10%'
                                        },

                                    }
                                }, function (data) { //opened handler
                                    data.childTable.jtable('load', { id: itemData.record.id });
                                });
                        });
                        //Return image to show on the person row
                        return $img;
                    }
                },
                Phones: {
                    title: '展开提报内容',
                    width: '4%',
                    sorting: false,
                    edit: false,
                    create: false,
                    listClass: 'child-opener-image-column',
                    display: function (itemData) {
                        //Create an image that will be used to open child table
                        var $img = $('<img class="child-opener-image" src="/Content/images/Misc/note.png" title="Edit exam results" />');
                        //Open child table when user clicks the image
                        $img.click(function () {
                            $('#T_ItemsTable').jtable('openChildTable',
                                $img.closest('tr'), //Parent row
                                {
                                    title: itemData.record.projectName,
                                    actions: {
                                        listAction: _t_RequireService.getPagedT_RequiresAsync

                                    },
                                    fields: {

                                        id: {
                                            key: true,
                                            create: true,
                                            edit: false,
                                            list: false
                                        },

                                        //checkKPoint: {
                                        //    title: '选择项',
                                        //    width: '10%'
                                        //},
                                        content: {
                                            title: '提报内容',
                                            width: '10%'
                                        },
                                        userName: {
                                            title: '提报人',
                                            width: '10%'
                                        },

                                    }
                                }, function (data) { //opened handler
                                    data.childTable.jtable('load', { Fk_Item_Require_Id: itemData.record.id });
                                });
                        });
                        //Return image to show on the person row
                        return $img;
                    }
                },
                projectName: {
                    title: '项目名称',
                    width: '10%'
                },

                count: { title: '提报人数', width: '3%' },


                createTime: {
                    title: '创建时间',
                    width: '8%'
                },

            },
            recordsLoaded: function (e, data) {
                var clipboard = new Clipboard('.copy', {
                    text: function (trigger) {
                        abp.notify.success("该地址已经复制，你可以使用Ctrl+V 粘贴。");
                        //alert($(this).attr('id'));
                        return window.location.protocol + "//" + window.location.host + '/WeChatRequire/Index';//?id=' + trigger.getAttribute('id');
                    }
                });


            }

        });



        //打开添加窗口SPA
        $('#CreateNewT_ItemButton').click(function () {
            //可选生成的对话框大小{size:'lg'}or{size:'sm'}
            //需要到_createContainer方法中添加,_args.size
            _createOrEditModal.open();
        });

        function copyToClipboard(txt) {
            client = new ZeroClipboard($(".fa-play-circle-o"));
            //clip.setHandCursor(true);
            client.on('load', function (client) {
                // alert( "movie is loaded" );

                client.on('datarequested', function (client) {
                    client.setText(this.innerHTML);
                });

                client.on('complete', function (client, args) {
                    alert("Copied text to clipboard: " + args.text);
                });
            });

            client.on('wrongflash noflash', function () {
                ZeroClipboard.destroy();
            });
            //clip.setText(txt);
            //clip.addEventListener('mouseOver', function (client) {
            //    // update the text on mouse over
            //    clip.setText(txt);
            //});

            //clip.addEventListener('complete', function (client, text) {
            //    //debugstr("Copied text to clipboard: " + text );
            //    abp.notify.success("该地址已经复制，你可以使用Ctrl+V 粘贴。");
            //});
            //clip.glue('clip_button', 'clip_container');
        }


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
                app.localize('T_ItemDeleteWarningMessage', t_Item.projectName),
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
        function getT_KPoints(reload) {
            if (reload) {
                _$t_ItemsTable.jtable('reload');
            } else {
                _$t_ItemsTable.jtable('load', {
                    filtertext: $('#T_ItemsTableFilter').val()
                });
            }
        }
        //删除当前t_KPoint实体
        function deleteT_KPoint(t_KPoint) {
            abp.message.confirm(
                app.localize('删除重点项', t_KPoint.trainContent),
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
