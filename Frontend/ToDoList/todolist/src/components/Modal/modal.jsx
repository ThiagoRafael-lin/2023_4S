export const Modal = ({
    fecharModal 
}) => {
    return (
        <>
            <div id="fundo-modal">
                <h3 id="titulo-modal">Descreva sua tarefa</h3>
                <input id="input-modal" type="text" placeholder="Exemplo de descrição" />
                <button id="button-modal"  onClick={(e) => { e.stopPropagation(); fecharModal(); }}>Confirmar tarefa</button>
            </div>
        </>
    )
}