#!/bin/bash
backup_dir=/export/backup/cold_backup
port=3306
ver=5639
mysql_base_dir=/export/mysql/${port}
date=`date +%Y%m%d%H%M%S`

if [ ! -d ${backup_dir} ]; then
    mkdir -p ${backup_dir}
fi

#stop mysql instance
echo "=========stop port:${port} mysql instance========="
/etc/init.d/mysqld_${ver} -P $port stop
if [ $? != 0 ];then
    echo "Mysql instance stop error,please check!"
    exit 1
fi

#cold backup data
echo "=========backup data========="
cd $mysql_base_dir
tar zcvf data_${date}.tar.gz data
mv data_${date}.tar.gz $backup_dir

#start mysql instance
echo "=========start port:${port} mysql instance========="
/etc/init.d/mysqld_${ver} -P $port start
if [ $? -eq 0 ];then
    echo ""
    echo "Backup OK!"
else
    echo "Backup ERROR!"
    echo "Check reason!"
fi

