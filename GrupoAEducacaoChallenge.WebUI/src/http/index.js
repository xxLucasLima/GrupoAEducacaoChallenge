import axios from "axios";

const baseURL = "https://localhost:44305/api"


export function getAlunos(callback, errorcallback) {
    axios
        .get(baseURL + "/Aluno")
        .then(res => {
            if (callback != null) {
                callback(res);
            }
        })
        .catch(err => {
            if (errorcallback != null) {
                errorcallback(err);
            }
        })
}

export function deleteAluno(id, callback, errorcallback) {

    axios
        .delete(baseURL + "/Aluno/" + id)
        .then(res => {
            if (callback != null) {
                callback(res);
            }
        })
        .catch(err => {
            if (errorcallback != null) {
                errorcallback(err);
            }
        })

}


export function createAluno(aluno, callback, errorcallback) {

    axios
        .post(baseURL + "/Aluno", aluno)
        .then(res => {
            if (callback != null) {
                callback(res);
            }
        })
        .catch(err => {
            if (errorcallback != null) {
                errorcallback(err);
            }
        })
}

export function updateAluno(aluno, callback, errorcallback) {

    axios
        .put(baseURL + "/Aluno/" + aluno.id, aluno)
        .then(res => {
            if (callback != null) {
                callback(res);
            }
        })
        .catch(err => {
            if (errorcallback != null) {
                errorcallback(err);
            }
        })
}
