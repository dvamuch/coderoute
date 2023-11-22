FROM node:lts-alpine

# делаем каталог 'app' текущим рабочим каталогом
WORKDIR /app

# добавляем `/app/node_modules/.bin` в $PATH
ENV PATH /app/node_modules/.bin:$PATH

# устанавливаем зависимости проекта
COPY package.json /app/package.json
RUN npm install
RUN npm install @vue/cli@5.0.8 -g

# копируем файлы и каталоги проекта в текущий рабочий каталог (т.е. в каталог 'app')

CMD ["npm", "run", "serve"]
