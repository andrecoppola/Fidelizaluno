import React from "react";
import { Route } from "react-router";
import Layout from './app/pages/layout/layout';

import { Switch } from 'react-router-dom';

import Home from './app/pages/homeDash/home';
import Painel from './app/pages/painel/painel';
import controleDePresenca from './app/pages/controleDePresenca/controleDePresenca';
import buscaAlunos from './app/pages/alunos/buscaAlunos/buscaAlunos';
import alunoPerfil from './app/pages/alunos/alunoPerfil';
import SimpleModalWrapped from './app/pages/chatbot/chatbot';
import alertaProcurados from './app/pages/procurados/alertaProcurados';
import alunosAusentes from './app/pages/alunos/alunosAusentes/alunosAusentes';
import login from './app/pages/login/Login'

export const routes = (
    <Switch>
        <Route exact path='/' component={login} />
        <Layout >
            <Switch>
                <Route path='/bot' component={SimpleModalWrapped} />
                <Route path='/home' component={Home} />
                <Route path='/buscaAlunos' component={buscaAlunos} />
                <Route path='/controleDePresenca' component={controleDePresenca} />
                <Route path='/painel' component={Painel} />
                <Route path='/aluno/:id' component={alunoPerfil} />
                <Route path='/procurados' component={alertaProcurados} />
                <Route path='/alunosAusentes' component={alunosAusentes} />
            </Switch>
        </Layout>
    </Switch>
);
