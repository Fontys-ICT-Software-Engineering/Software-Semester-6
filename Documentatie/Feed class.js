wachtwoord mysql database:
#3WR$G28ZGl


$ kubectl run -it --rm --image=mysql:8.0 --restart=Never mysql-client -- mysql -h mysql-clusterip-srv -password="#3WR$G28ZGl"

commands run:

kubectl apply -f carmicroservice-deployment.yaml

Ik heb afgelopen maandag een fijn gesprek gehad met mijn semestercoach over de stage mogelijkheid bij KJ Software. 

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

gcloud artifacts repositories add-iam-policy-binding kubernetes \
    --location=europe-west4 \
    --member=serviceAccount:258862840749-compute@developer.gserviceaccount.com \
    --role="roles/artifactregistry.reader"
	
	kubectl create deployment hello-app --image=fendamear/kweetservice:latest
	
	docker build -t europe-west4-docker.pkg.dev/${PROJECT_ID}/kubernetes/kweetservice:v1 .
	
	docker run --rm -p 8080:8080 europe-west4-docker.pkg.dev/${PROJECT_ID}/kubernetes/kweetservice:v1

gcloud auth configure-docker europe-west4-docker.pkg.dev

docker push europe-west4-docker.pkg.dev/${PROJECT_ID}/kubernetes/kweetservice:v1



az webapp connection create mysql
-g Kwetter-DB
-n KweetService20230427001947
--tg Kwetter-DB
--server kwetter-db.mysql.database.azure.com
--database Kwetter
--system-identity

werkzaamheden sprint 
software architectuur met wat al gemaakt is
laten zien online deployment applicatie
roadmap

valideren security
monitoring in de cloud
ontkoppeling schrijven/lezen
onderzoek capteren CAP theorum

focus op kubernetes en CI/CD

dis data
verschillende database engines
AVG (security)
func. maken voor verwijderen gebruiker (anoniem maken/verwijderen)
CQRS

helm install ingress-nginx ingress-nginx/ingress-nginx --namespace ingress-basic --set controller.replicaCount=1 --set controller.nodSelector."beta\.kubernetes\.io/os="=linux --set controller.service.externalTrafficPolicy=Local


$ docker run -d --hostname localhost --name test-naam -e RABBITMQ_DEFAULT_USER=guest -e RABBITMQ_DEFAULT_PASS=guest rabbitmq:3-management

