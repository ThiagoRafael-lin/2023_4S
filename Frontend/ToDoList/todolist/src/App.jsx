import "./App.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPen } from "@fortawesome/free-solid-svg-icons";
import { faXmark } from "@fortawesome/free-solid-svg-icons";
import { faMagnifyingGlass } from "@fortawesome/free-solid-svg-icons";

function App() {
  return (
    <>
      <main id="principal-container">
        <div id="principal-content">
          {/* AREA DE PROCURAR TAREFA */}
          <h3 id="dia-da-semana">
            Terça-Feira, <span id="dia-span">24</span> de julho
            <input id="procurar" type="text" placeholder="Procurar tarefa" />
          </h3>
          <div id="dia-da-semana-icon">
            <FontAwesomeIcon icon={faMagnifyingGlass} />
          </div>

          {/* AREA DE VISUAZLIAR TAREFAS */}
          <section id="tarefas-container">
            <div id="tarefas-content">
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
            </div>
            <div id="tarefas-content">
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
            </div>
          </section>
        </div>
      </main>

      {/* BOTÃO NOVA TAREFA */}
      <div id="nova-tarefa-container">
        <button id="nova-tarefa-button">Nova tarefa</button>
      </div>
    </>
  );
}

export default App;
