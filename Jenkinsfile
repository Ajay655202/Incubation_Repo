pipeline {
    agent any

    environment {
        SOLUTION_NAME = "Incubation_DotNet.sln"
        TEST_DLL = "D:\\Incubation_Repo\\LoggingAutomation\\bin\\Debug\\net6.0\\LoggingAutomation.dll"
        GIT_REPO = "https://github.com/Ajay655202/Incubation_Repo.git"
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: "${GIT_REPO}"
            }
        }

        stage('Restore Packages') {
            steps {
                bat "nuget restore ${SOLUTION_NAME}"
            }
        }

        stage('Build Solution') {
            steps {
                bat "\"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe\" ${SOLUTION_NAME} /p:Configuration=Debug"
            }
        }

        stage('Run Regression Tests') {
            steps {
                bat "\"C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe\" ${TEST_DLL} --TestCaseFilter:TestCategory=Regression /logger:trx"
            }
        }

        stage('Publish Results') {
            steps {
                mstest testResultsFile:"**/*.trx"
            }
        }
    }
}
