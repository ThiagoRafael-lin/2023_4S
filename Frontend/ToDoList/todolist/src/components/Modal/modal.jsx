export const Modal = ({
    fecharModal,
    adicionarTarefa
}) => {

    const handleSubmit = (event) => {
        event.preventDefault();
        const texto = document.getElementById('input-modal').value;
        adicionarTarefa(texto);
        fecharModal();
    };

    return (
        <>
            <form onSubmit={handleSubmit}>
                <div id="fundo-modal">
                    <h3 id="titulo-modal">Descreva sua tarefa</h3>
                    <input id="input-modal" type="text" placeholder="Exemplo de descrição" required />
                    <button id="button-modal" type="submit">Confirmar tarefa</button>

                    {/* <button id="button-modal" onClick={(e) => { e.stopPropagation(); fecharModal(); }}>Confirmar tarefa</button> */}
                </div>
            </form>
        </>
    )
}