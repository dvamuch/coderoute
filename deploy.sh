#!/bin/sh

ssh -p 2425 root@10.0.2.15 /bin/bash <<EOF 
<<<<<<< HEAD
  #sudo echo "New value"
  cd fronted_project
=======
<<<<<<< HEAD
  #sudo echo "New value"
  cd fronted_project
=======
  sudo echo "New value"
  cd frontend_projectv2
>>>>>>> af15133220a6cde7e022226a0a2eace6e39f3148
>>>>>>> master
  cd coderoute
  git add .
  git commit -m "Local changes"
  git pull origin master
<<<<<<< HEAD
  # npm run build
  # cp -r dist/* /usr/share/nginx/html/domain/
=======
 # npm run build
#  cp -r dist/* /usr/share/nginx/html/domain/
>>>>>>> master
  exit
EOF
