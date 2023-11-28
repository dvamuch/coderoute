#!/bin/sh

ssh evgeny@10.128.0.31 /bin/bash <<EOF 
  cd project
  cd coderoute
  git add .
  git commit -m "Local changes now"
  git pull origin master
  exit
EOF
