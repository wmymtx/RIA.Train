



    $(function () {

        var $ShowT_StaffsTable = $('#ShowT_StaffsTable');
        var t_CInfoService = abp.services.app.t_HClass;



        $ShowT_StaffsTable.jtable({

            title: app.localize('T_Item'),
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
                listAction: t_CInfoService.getPagedT_HClasssAsync

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

                        // }
                        //删除
                        //  if (_permissions.delete) {
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('删除') + '"><i class="fa fa-trash-o"></i></button>')
                            .appendTo($span)
                            .click(function () {
                                deleteT_Item({ id: data.record.id });
                            });
                        // }
                        //添加
                        // if (_permissions.create) {

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

                userName: {
                    title: '姓名',
                    width: '10%'
                },

            }

        });



        getT_Items();


        //模糊查询功能
        function getT_Items(reload) {
            if (reload) {
                $ShowT_StaffsTable.jtable('reload');
            } else {
                $ShowT_StaffsTable.jtable('load', {
                    filtertext: $('#T_ItemsTableFilter').val(),
                    FK_ClassId: $("#fk_Id").val()
                });
            }
        }
        //
        //删除当前t_Item实体
        function deleteT_Item(t_Item) {
            //abp.message.confirm(
            //    app.localize('T_ItemDeleteWarningMessage', t_Item.projectName),
            //    function (isConfirmed) {
            //        if (isConfirmed) {
                        t_CInfoService.deleteT_HClassAsync({
                            id: t_Item.id
                        }).done(function () {
                            getT_Items(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
            //        }
            //    }
            //);
        }
        function getT_KPoints(reload) {
            if (reload) {
                $ShowT_StaffsTable.jtable('reload');
            } else {
                $ShowT_StaffsTable.jtable('load', {
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

