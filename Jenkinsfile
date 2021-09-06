pipeline {
    agent { label 'ubuntu_mac' }

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
                        echo "Building tag with marsroverexpedition:latest."
                        sh "pwd"
                        sh "docker build -t 54.226.170.75:8002/marsroverexpedition:latest ."
                        sh "docker push 54.226.170.75:8002/marsroverexpedition:latest"
                        sh "docker image rm 54.226.170.75:8002/marsroverexpedition:latest"
                        echo "finish Docker stage."
                    }		
				}

			}
		 } 
		 stage('Deployment') {
		 	steps {
				script{
					if(env.BRANCH_NAME == 'master') {
						echo "Deployment to master environment"
// 						configFileProvider([configFile(fileId: '2d50994e-a2eb-4c1b-9575-edfdec99c3a0', targetLocation: './config/libConfig.json')]) {}
//                         configFileProvider([configFile(fileId: '8f9c6e39-e87a-4b7d-a7f0-a62fdaf822be', targetLocation: './config/service.json')]) {}
				  		sshPublisher(publishers: [sshPublisherDesc(configName: 'unbuntu_54_226_170_75', transfers: [sshTransfer(cleanRemote: false, excludes: '', execCommand: '''
						  pwd
						  sudo docker stop marsroverexpedition 
						  sudo docker rm marsroverexpedition
						  sudo docker pull 127.0.0.1:8002/marsroverexpedition:latest 
                          sudo docker run --name marsroverexpedition -d  -e ASPNETCORE_ENVIRONMENT="Development" -p 8004:80 127.0.0.1:8002/marsroverexpedition:latest
						   ''', execTimeout: 120000, flatten: false, makeEmptyDirs: false, noDefaultExcludes: false, patternSeparator: '[, ]+',
						    remoteDirectory: 'MarsRoverExpedition/', remoteDirectorySDF: false, removePrefix: '', sourceFiles: 'config/*.json')],
						     usePromotionTimestamp: false, useWorkspaceInPromotion: false, verbose: true)])       
					}
				}

			}
		 }
		 
    }
}
