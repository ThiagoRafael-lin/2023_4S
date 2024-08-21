// FONTS
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPen } from "@fortawesome/free-solid-svg-icons";
import { faXmark } from "@fortawesome/free-solid-svg-icons";
import { faMagnifyingGlass } from "@fortawesome/free-solid-svg-icons";
// TELAS
import "./App.css";
import "./components/Modal/modal";
import { Modal } from "./components/Modal/modal";
import { useNavigate } from "react-router-dom";
import { useState } from "react";


function App() {

  // PEGO O DIA ATUAL
  const diaAtual = new Date();
  const dia = diaAtual.getDate();
  const diaFormatado = String(dia).padStart(2, '0');

  const [modalEstaVisivel, setModalEstaVisibel] = useState(false);
  const [tarefas, setTarefas] = useState([
    // {
    //   id: 1,
    //   texto: "Estudar React",
    //   concluido: false
    // },
    // {
    //   id: 2,
    //   texto: "Estudar c#",
    //   concluido: false
    // },
    // {
    //   id: 3,
    //   texto: "Estudar java",
    //   concluido: false
    // },
  ])

  const deletarTarefa = (id) => {
    setTarefas(tarefas.filter(tarefa => tarefa.id !== id));
  };

  const novaTarefaClicado = () => {
    setModalEstaVisibel(true);
  };

  const fecharNovaTarefa = () => {
    setModalEstaVisibel(false)
  };

  const adicionarTarefa = (texto) => {
    const novaTarefa = {
      id: Math.random(), // Gera um ID único para a tarefa
      texto,
      concluido: false, // Supondo que você tenha uma opção para marcar tarefas como concluídas
    };
    setTarefas([...tarefas, novaTarefa]);
  };


  return (
    <>

      <main id="principal-container" className={modalEstaVisivel ? "blur-background" : ""}>
        <div id="principal-content">
          {/* AREA DE PROCURAR TAREFA */}
          <h3 id="dia-da-semana">
            Terça-Feira, <span id="dia-span">{diaFormatado}</span> de julho
            <input id="procurar" type="text" placeholder="Procurar tarefa" />
          </h3>
          <div id="dia-da-semana-icon">
            <FontAwesomeIcon icon={faMagnifyingGlass} />
          </div>

          {/* AREA DE VISUAZLIAR TAREFAS */}
          <section id="tarefas-container">
            {tarefas.map((tarefa) => (
              <div id="tarefas-content">
                <input id="checkbox" type="checkbox" name="" checked={tarefa.concluido} onChange={() => { }} />
                <label id="tarefa-texto" htmlFor="">
                  {tarefa.texto}
                  {/* Começar a execução do projeto */}
                </label>
                <button id="tarefas-icon-close"  onClick={() => deletarTarefa(tarefa.id)}>
                  <FontAwesomeIcon icon={faXmark} size="lg" />
                </button>
                <button id="tarefas-icon-edit" onClick={() => abrirFormularioEdicao(tarefa.id)}>
                  <FontAwesomeIcon icon={faPen} />
                </button>
              </div>
            ))}
            {/* <div id="tarefas-content">
              <input id="checkbox" type="checkbox" name="" />
              <label id="tarefa-texto" htmlFor="">
                Começar a execução do projeto
              </label>
              <button id="tarefas-icon-close">
                <FontAwesomeIcon icon={faXmark} size="lg" />
              </button>
              <button id="tarefas-icon-edit">
                <FontAwesomeIcon icon={faPen} />
              </button>
            </div> */}
          </section>
        </div>
      </main>

      {/* BOTÃO NOVA TAREFA */}
      <div id="nova-tarefa-container">
        <button id="nova-tarefa-button" onClick={setModalEstaVisibel}>Nova tarefa</button>
      </div>

      {modalEstaVisivel && <Modal fecharModal={fecharNovaTarefa} adicionarTarefa={adicionarTarefa} deletarTarefa={deletarTarefa} />}

      {/* {modalEstaVisivel && <Modal fecharModal={fecharNovaTarefa} />} */}


    </>
  );
}

export default App;
