#!/bin/sh

ssh evgeny@10.128.0.21 /bin/bash <<EOF 
  touch file_new.txt
  exit
EOF
