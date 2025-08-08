export function iniciarKonami(dotnetHelper) {
  const konamiCode = [
    "arrowup",
    "arrowup",
    "arrowdown",
    "arrowdown",
    "arrowleft",
    "arrowright",
    "arrowleft",
    "arrowright",
    "b",
    "a",
  ];

  let inputSequence = [];

  document.addEventListener("keydown", function (e) {
    inputSequence.push(e.key.toLowerCase());
    if (inputSequence.length > konamiCode.length) {
      inputSequence.shift();
    }

    const currentSequence = inputSequence.join(",");
    const targetSequence = konamiCode.join(",");

    if (currentSequence === targetSequence) {
      inputSequence = [];
      dotnetHelper.invokeMethodAsync("MostrarKratos");
    }
  });
}
