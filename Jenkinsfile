pipeline {
    agent { label 'aws_dev_54_226_170_75_slave' }

    stages {
		stage ('Clean workspace') {
			steps {
				cleanWs()
			}
		}
		stage('Build') {
			steps {
				echo 'Pulling...' + env.BRANCH_NAME
				checkout scm
			 }
		 }
		stage('Test') {
		  steps {
		  		echo 'Running test ...' + env.BRANCH_NAME
		  }
		}
		stage('Docker') {
			steps {
				script {	
                    if(env.BRANCH_NAME == 'master'){
                        echo "Building tag with ${env.BUILD_ID}"
                    }		
// 					if(env.BRANCH_NAME == 'dev'){
// 						echo "Building tag with ${env.BUILD_ID}"
// 						sh "aws ecr get-login-password --region us-east-1 | docker login --username AWS --password-stdin 231587286057.dkr.ecr.us-east-1.amazonaws.com"
// 						sh "sudo docker build -t appointment-api:dev${env.BUILD_ID} ."
// 						sh "docker tag appointment-api:dev${env.BUILD_ID} 231587286057.dkr.ecr.us-east-1.amazonaws.com/appointment-api:dev${env.BUILD_ID}"
// 						sh "docker push 231587286057.dkr.ecr.us-east-1.amazonaws.com/appointment-api:dev${env.BUILD_ID}"
// 						sh "docker image rm appointment-api:dev${env.BUILD_ID}"
// 						sh "docker image rm 231587286057.dkr.ecr.us-east-1.amazonaws.com/appointment-api:dev${env.BUILD_ID}"
// 					}
// 
// 					if(env.BRANCH_NAME == 'stage'){
// 						echo "Building tag with ${env.BUILD_ID}"
// 						sh "aws ecr get-login-password --region us-east-1 | docker login --username AWS --password-stdin 231587286057.dkr.ecr.us-east-1.amazonaws.com"
// 						sh "sudo docker build -t appointment-api:stage${env.BUILD_ID} ."
// 						sh "docker tag  appointment-api:stage${env.BUILD_ID} 231587286057.dkr.ecr.us-east-1.amazonaws.com/appointment-api:stage${env.BUILD_ID}"
// 						sh "docker push 231587286057.dkr.ecr.us-east-1.amazonaws.com/appointment-api:stage${env.BUILD_ID}"
// 						sh "docker image rm  appointment-api:stage${env.BUILD_ID}"
// 						sh "docker image rm 231587286057.dkr.ecr.us-east-1.amazonaws.com/appointment-api:stage${env.BUILD_ID}"
// 					}
				}

			}
		 } 
// 		 stage('Deployment') {
// 		 	steps {
// 				script{
// 					if(env.BRANCH_NAME == 'dev') {
// 						echo "Deployment to dev environment"
// 						configFileProvider([configFile(fileId: '2d50994e-a2eb-4c1b-9575-edfdec99c3a0', targetLocation: './config/libConfig.json')]) {}
//                         configFileProvider([configFile(fileId: '8f9c6e39-e87a-4b7d-a7f0-a62fdaf822be', targetLocation: './config/service.json')]) {}
// 				  		sshPublisher(publishers: [sshPublisherDesc(configName: 'aws-api-gate-dev', transfers: [sshTransfer(cleanRemote: false, excludes: '', execCommand: '''
// 						  pwd
// 						  cd  appointmentapi
// 						  sh deploy.sh dev${BUILD_NUMBER} ''', execTimeout: 120000, flatten: false, makeEmptyDirs: false, noDefaultExcludes: false, patternSeparator: '[, ]+', remoteDirectory: 'appointmentapi/', remoteDirectorySDF: false, removePrefix: '', sourceFiles: 'config/*.json')], usePromotionTimestamp: false, useWorkspaceInPromotion: false, verbose: true)])       
// 					}
// 					
// 					if(env.BRANCH_NAME == 'stage') {
//                         echo "Deployment to stage environment"
// 						// configFileProvider([configFile(fileId: '834dd8fd-0b28-4841-965b-0202f9bee55e', targetLocation: './config/appsettings.json')]) {}
//                         // configFileProvider([configFile(fileId: 'f23a78ab-09f2-4e10-aac2-a67d0af4df49', targetLocation: './config/App.config')]) {}
// 				  		sshPublisher(publishers: [sshPublisherDesc(configName: 'aws-api-gate-dev', transfers: [sshTransfer(cleanRemote: false, excludes: '', execCommand: '''
// 						  pwd
// 						  cd  appointmentapi
// 						  sh deploy.sh stage${BUILD_NUMBER} ''', execTimeout: 120000, flatten: false, makeEmptyDirs: false, noDefaultExcludes: false, patternSeparator: '[, ]+', remoteDirectory: 'appointmentapi/', remoteDirectorySDF: false, removePrefix: '', sourceFiles: 'config/*.json')], usePromotionTimestamp: false, useWorkspaceInPromotion: false, verbose: true)])
// 					}
// 				}
// 
// 			}
// 		 }
		 
    }
}
