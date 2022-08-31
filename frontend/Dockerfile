FROM node:16 AS build
WORKDIR /app
COPY package.json package.json
RUN npm install
COPY . .
RUN npm run build --prod

FROM nginx:latest AS webserver
COPY --from=build /app/dist/frontend /usr/share/nginx/html
COPY /nginx.conf  /etc/nginx/conf.d/default.conf
EXPOSE 8080
CMD ["nginx", "-g", "daemon off;"]
