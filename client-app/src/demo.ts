const duck1 = {
    name: 'huey',
    numLegs: 2,
    makeSound: (sound: any) => console.log(sound)
}

const duck2 = {
    name: 'duey',
    numLegs: 2,
    makeSound: () => console.log('quack')
}
export const ducks=[duck1,duck2]