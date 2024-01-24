FROM mysql:5.7.22
EXPOSE 3306
COPY ./WebApplication1/db/migrations/ /home/database/
COPY ./WebApplication1/db/dataset/ /home/database/
COPY ./WebApplication1/ci/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh