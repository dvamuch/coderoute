#!/bin/sh


ssh evgeny@10.128.0.31 /bin/bash <<EOF
  cd project
  cd coderoute
  git pull origin dev
  exit
EOF
