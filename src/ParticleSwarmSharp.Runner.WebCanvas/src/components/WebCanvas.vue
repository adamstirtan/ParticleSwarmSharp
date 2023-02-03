<template>
    <h1>Particle Swarm Sharp</h1>
    <p>Particle Swarm Optimization (PSO) is a population-based algorithm that models the behavior of a swarm of particles moving in a multidimensional space. Each particle represents a potential solution to the optimization problem, and its position in the space represents the values of the variables in that solution. The particles in the swarm are initialized with random positions and velocities, and then iteratively update their positions based on their own best solution (the “personal best”), as well as the best solution found by the entire swarm (the “global best”). The idea is that the particles will move towards regions of the space that contain better solutions, and eventually converge on the optimal solution.</p>
    <div id="plot"></div>
</template>

<script>
import Plotly from 'plotly.js-dist-min'

export default {

    data() {
        return {
            iteration: 0,
            particles: [],
            particleCount: 100,
            xMin: -10,
            xMax: 10,
            vMin: -1,
            vMax: 1,
            c1: 2,
            c2: 2,
            w: 0.7
        };
    },
    mounted() {
        this.initializeParticles();
        this.runOptimization();
    },
    methods: {
        initializeParticles() {
            for (let i = 0; i < this.particleCount; i++) {
                let x = Math.random() * (this.xMax - this.xMin) + this.xMin;
                let v = Math.random() * (this.vMax - this.vMin) + this.vMin;

                this.particles.push({
                    x: x,
                    v: v,
                    pBest: x,
                    fBest: x * x
                });
            }
        },
        runOptimization() {
            let gBest = this.particles[0].pBest;
            let gBestF = this.particles[0].fBest;

            for (let i = 1; i < this.particles.length; i++) {
                if (this.particles[i].fBest < gBestF) {
                    gBest = this.particles[i].pBest;
                    gBestF = this.particles[i].fBest;
                }
            }

            for (let i = 0; i < this.particles.length; i++) {
                let particle = this.particles[i];
                particle.v = this.w * particle.v + this.c1 * Math.random() * (particle.pBest - particle.x) + this.c2 * Math.random() * (gBest - particle.x);
                particle.x += particle.v;
                let f = particle.x * particle.x;
                if (f < particle.fBest) {
                    particle.pBest = particle.x;
                    particle.fBest = f;
                }
            }

            this.plotIteration();
        },
        plotIteration() {
            console.log("plotting");
            let x = [];
            let y = [];

            for (let i = 0; i < this.particles.length; i++) {
                x.push(this.particles[i].x);
                y.push(this.particles[i].x * this.particles[i].x);
            }

            Plotly.newPlot("plot", [{
                x: x,
                y: y,
                mode: 'markers',
                marker: {
                    color: 'red',
                    size: 4
                }
            }, {
                x: [-10, 10],
                y: [0, 0],
                mode: 'lines',
                line: {
                    color: 'black',
                    width: 2
                }
            }], {
                title: 'Particle Swarm Optimization of y=x^2',
                xaxis: {
                    title: 'X'
                },
                yaxis: {
                    title: 'Y'
                }
            });
        }
    }
}

</script>

<style scoped>
    #plot {
        border: 1px solid #ccc;
    }
    p {
        padding: 0 2rem;
    }
</style>