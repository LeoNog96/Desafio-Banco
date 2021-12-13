FROM node

COPY package*.json ./

RUN npm install

COPY . .

RUN npm run build

ENV TZ=America/Sao_Paulo

RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

EXPOSE 3000

WORKDIR public/

CMD [ "npx", "serve" ]