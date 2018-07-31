#!/bin/bash
backup_dir=/export/backup/cold_backup
port=3306
ver=5639
mysql_base_dir=/export/mysql/${port}
date=`date +%Y%m%d%H%M%S`
backup_file=$1

if [ ! -d ${backup_dir} ]; then
    mkdir -p ${backup_dir}
fi

if [ ! -f ${backup_dir}/${backup_file} ]; then
    echo "The backup file:${backup_dir}/${backup_file} is not exists,please check!"
    basename=`basename "$0"`
    echo "Usage: $basename 备份文件名"
    exit 1
fi

#stop mysql instance
echo "=========stop port:${port} mysql instance========="
/etc/init.d/mysqld_${ver} -P $port stop
if [ $? != 0 ];then
    echo "Mysql instance stop error,please check!"
    exit 2
fi

#cold backup data
echo "=========backup current data========="
cd $mysql_base_dir
tar zcvf data_${date}.tar.gz data
mv data_${date}.tar.gz $backup_dir
rm -rf data

#recover data
echo "=========recover data========="
cd $backup_dir
rm -rf data
tar zxvf $backup_file
mv data $mysql_base_dir
chown -R mysql.mysql $mysql_base_dir

#start mysql instance
echo "=========start port:${port} mysql instance========="
/etc/init.d/mysqld_${ver} -P $port start
if [ $? -eq 0 ];then
    echo ""
    echo "Recover OK!"
else
    echo "Recover ERROR!"
    echo "Check reason!"
fi
